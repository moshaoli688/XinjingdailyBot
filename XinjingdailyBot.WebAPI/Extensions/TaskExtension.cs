using Quartz;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using XinjingdailyBot.Infrastructure;
using XinjingdailyBot.Infrastructure.Attribute;

namespace XinjingdailyBot.WebAPI.Extensions;

/// <summary>
/// Telegram扩展
/// </summary>
public static class TaskExtension
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    /// <summary>
    /// 注册定时任务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    [RequiresUnreferencedCode("不兼容剪裁")]
    public static void AddTasks(this IServiceCollection services, IConfiguration configuration)
    {
        var scheduleConfig = configuration.GetSection("Schedule").Get<OptionsSetting.ScheduleOption>();
        var cron = scheduleConfig?.Cron ?? new Dictionary<string, string>();

        var tasks = Assembly.Load("XinjingdailyBot.Tasks").GetTypes();
        if (tasks == null)
        {
            return;
        }

        services.AddQuartz(qz => {
            qz.UseMicrosoftDependencyInjectionJobFactory();

            _logger.Debug($"===== 注册定时任务 =====");
            uint count = 0;
            foreach (var jobType in tasks)
            {
                var jobAttribute = jobType.GetCustomAttribute<JobAttribute>();
                if (jobAttribute != null)
                {
                    var group = jobAttribute.Group ?? "DEFAULT";
                    var jobKey = new JobKey(jobType.Name, group);
                    var tiggerKey = new TriggerKey(jobType.Name + "-Tigger", group);

                    var schedule = cron.GetValueOrDefault(jobType.Name, jobAttribute.Schedule);

                    qz.AddJob(jobType, jobKey, opts => opts.WithIdentity(jobKey));
                    qz.AddTrigger(opts => opts
                        .ForJob(jobKey)
                        .WithIdentity(tiggerKey)
                        .WithCronSchedule(schedule)
                    );

                    _logger.Debug($"[{schedule}] - {jobType}");
                    count++;
                }
            }
            _logger.Debug($"===== 注册了 {count} 定时任务 =====");
        });

        services.AddQuartzServer(op => {
            op.StartDelay = TimeSpan.FromSeconds(10);
            op.AwaitApplicationStarted = true;
            op.WaitForJobsToComplete = true;
        });
    }
}
