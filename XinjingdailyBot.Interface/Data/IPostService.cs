﻿using XinjingdailyBot.Interface.Data.Base;
using XinjingdailyBot.Model.Models;

namespace XinjingdailyBot.Interface.Data
{
    [Obsolete("待重构")]
    public interface IPostService : IBaseService<OldPosts>
    {
        /// <summary>
        /// 文字投稿长度上限
        /// </summary>
        //public static int MaxPostText { get; } = 2000;

        /// <summary>
        /// 接受投稿
        /// </summary>
        /// <param name="post"></param>
        /// <param name="dbUser"></param>
        /// <param name="callbackQuery"></param>
        /// <returns></returns>
        //Task AcceptPost(OldPosts post, Users dbUser, CallbackQuery callbackQuery);
        /// <summary>
        /// 检查用户是否达到每日投稿上限
        /// </summary>
        /// <param name="dbUser"></param>
        /// <returns>true: 可以继续投稿 false: 无法继续投稿</returns>
        //Task<bool> CheckPostLimit(Users dbUser, Message? message = null, CallbackQuery? query = null);
        /// <summary>
        /// 从审核回调中获取稿件
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        //Task<OldPosts?> FetchPostFromReviewCallbackQuery(CallbackQuery message);
        /// <summary>
        /// 从回复的消息获取稿件
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        //Task<OldPosts?> FetchPostFromReplyToMessage(Message message);
        /// <summary>
        /// 从确认投稿回调中获取稿件
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //Task<OldPosts?> FetchPostFromConfirmCallbackQuery(CallbackQuery query);

        /// <summary>
        /// 处理多媒体投稿(mediaGroup)
        /// </summary>
        /// <param name="dbUser"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        //Task HandleMediaGroupPosts(Users dbUser, Message message);
        /// <summary>
        /// 处理多媒体投稿
        /// </summary>
        /// <param name="dbUser"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        //Task HandleMediaPosts(Users dbUser, Message message);
        /// <summary>
        /// 处理文字投稿
        /// </summary>
        /// <param name="dbUser"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        //Task HandleTextPosts(Users dbUser, Message message);
        /// <summary>
        /// 拒绝投稿
        /// </summary>
        /// <param name="post"></param>
        /// <param name="dbUser"></param>
        /// <param name="rejectReason"></param>
        /// <returns></returns>
        //Task RejetPost(OldPosts post, Users dbUser, string rejectReason);
        /// <summary>
        /// 设置稿件Tag
        /// </summary>
        /// <param name="post"></param>
        /// <param name="tagId"></param>
        /// <param name="callbackQuery"></param>
        /// <returns></returns>
        //Task SetPostTag(OldPosts post, int tagId, CallbackQuery callbackQuery);
        /// <summary>
        /// 设置稿件Tag
        /// </summary>
        /// <param name="post"></param>
        /// <param name="payload"></param>
        /// <param name="callbackQuery"></param>
        /// <returns></returns>
        //Task SetPostTag(OldPosts post, string payload, CallbackQuery callbackQuery);
    }
}
