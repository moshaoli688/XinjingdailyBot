using Telegram.Bot.Types;
using XinjingdailyBot.Interface.Data.Base;
using XinjingdailyBot.Model.Models;

namespace XinjingdailyBot.Interface.Data;

/// <summary>
/// 消息记录仓储服务
/// </summary>
public interface IDialogueService : IBaseService<Dialogue>
{
    /// <summary>
    /// 记录群组聊天消息
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task RecordMessage(Message message);
}
