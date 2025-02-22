using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types.Enums;

namespace XinjingdailyBot.WebAPI.IPC.Data;

/// <summary>
/// 投稿数据
/// </summary>
public sealed record CreatePostData
{
    /// <summary>
    /// 文字描述
    /// </summary>
    [MaxLength(2000)]
    [DefaultValue("")]
    public string Text { get; set; } = "";
    /// <summary>
    /// 匿名投稿
    /// </summary>
    [DefaultValue(false)]
    public bool Anonymous { get; set; }
    /// <summary>
    /// 多媒体文件
    /// </summary>
    public IFormFileCollection? Media { get; set; }
    /// <summary>
    /// 转发频道来源
    /// </summary>
    public FromData? From { get; set; }
    /// <summary>
    /// 消息类型
    /// </summary>
    [DefaultValue(MessageType.Unknown)]
    public MessageType PostType { get; set; } = MessageType.Unknown;
    /// <summary>
    /// 是否启用遮罩
    /// </summary>
    [DefaultValue(false)]
    public bool HasSpoiler { get; set; }
}

/// <summary>
/// 转发来源
/// </summary>
public sealed record FromData
{
    /// <summary>
    /// 频道ID
    /// </summary>
    [DefaultValue(-1)]
    public long ChannelID { get; set; }
    /// <summary>
    /// 频道ID @
    /// </summary>
    [DefaultValue("")]
    public string ChannelName { get; set; } = "";
    /// <summary>
    /// 频道名称
    /// </summary>
    [DefaultValue("")]
    public string ChannelTitle { get; set; } = "";
    /// <summary>
    /// 转发消息ID
    /// </summary>
    [DefaultValue(-1)]
    public long ChannelMsgID { get; set; } = -1;
}
