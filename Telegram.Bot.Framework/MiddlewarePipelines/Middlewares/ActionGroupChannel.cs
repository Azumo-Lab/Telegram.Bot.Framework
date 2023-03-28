﻿//  <Telegram.Bot.Framework>
//  Copyright (C) <2022 - 2023>  <Azumo-Lab> see <https://github.com/Azumo-Lab/Telegram.Bot.Framework/>
//
//  This file is part of <Telegram.Bot.Framework>: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.

using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstract;
using Telegram.Bot.Framework.Abstract.Middlewares;
using Telegram.Bot.Framework.Abstract.Sessions;

namespace Telegram.Bot.Framework.MiddlewarePipelines.Middlewares
{
    /// <summary>
    /// 用于处理频道群组消息的Action
    /// </summary>
    public class ActionGroupChannel : IMiddleware
    {
        public async Task Execute(TelegramSession Context, MiddlewareHandle NextHandle)
        {
            //IBotChatTypeProc botChatTypeProc;
            //switch (Context.Update.Message.Chat.Type)
            //{
            //    case Types.Enums.ChatType.Private:
            //        break;
            //    case Types.Enums.ChatType.Group:
            //        botChatTypeProc = Context.UserService.GetService<IBotChatTypeProc>();
            //        botChatTypeProc.Group(Context);
            //        return;
            //    case Types.Enums.ChatType.Channel:
            //        botChatTypeProc = Context.UserService.GetService<IBotChatTypeProc>();
            //        botChatTypeProc.Channel(Context);
            //        break;
            //    case Types.Enums.ChatType.Supergroup:
            //        botChatTypeProc = Context.UserService.GetService<IBotChatTypeProc>();
            //        botChatTypeProc.Group(Context);
            //        break;
            //    case Types.Enums.ChatType.Sender:
            //        break;
            //}

            await NextHandle(Context);
        }
    }
}