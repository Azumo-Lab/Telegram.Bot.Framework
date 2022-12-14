//  <Telegram.Bot.Framework>
//  Copyright (C) <2022>  <Azumo-Lab> see <https://github.com/Azumo-Lab/Telegram.Bot.Framework/>
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Components;
using Telegram.Bot.Framework.InternalFramework.InterFaces;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Framework.TelegramControllerEX
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TelegramControllerPartial
    {
        public TelegramContext Context { get; internal set; }

        internal IServiceProvider OneTimeService;
        internal IServiceProvider UserService;

        /// <summary>
        /// 获取命令信息文本
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCommandInfosString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            GetCommandInfos().ForEach(x =>
            {
                stringBuilder.AppendLine($"{x.CommandName}  {x.CommandInfo}");
            });
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 获取命令信息
        /// </summary>
        /// <returns></returns>
        protected virtual List<(string CommandName, string CommandInfo)> GetCommandInfos()
        {
            ITypeManager typeManger = UserService.GetService<ITypeManager>();
            return typeManger.GetCommandInfos()
                .Select(x => (x.CommandAttribute.CommandName, x.CommandAttribute.CommandInfo))
                .ToList();
        }

        protected virtual string CreateCallBack(Action<TelegramContext, IServiceScope> callback)
        {
            if (callback == null)
                return null;

            ICallBackManager callBackManger = UserService.GetService<ICallBackManager>();

            return callBackManger.CreateCallBack(callback);
        }

        protected virtual IEnumerable<InlineKeyboardButton> CreateInlineKeyboardButton(IEnumerable<InlineButtons> keyboardButton)
        {
            IEnumerable<InlineKeyboardButton> inlineKeyboardButtons = keyboardButton.Select(x => new InlineKeyboardButton(x.Text)
            {
                CallbackData = CreateCallBack(x.Callback),
                CallbackGame = x.CallbackGame,
                Url = x.Url,
                LoginUrl = x.LoginUrl,
                Pay = x.Pay,
                SwitchInlineQuery = x.SwitchInlineQuery,
                SwitchInlineQueryCurrentChat = x.SwitchInlineQueryCurrentChat,
                WebApp = x.WebApp,
            }).ToList();

            return inlineKeyboardButtons;
        }
    }
}

