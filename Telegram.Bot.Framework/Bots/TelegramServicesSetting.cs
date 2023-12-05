﻿//  <Telegram.Bot.Framework>
//  Copyright (C) <2022 - 2024>  <Azumo-Lab> see <https://github.com/Azumo-Lab/Telegram.Bot.Framework/>
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

using System.Diagnostics;
using Telegram.Bot.Framework.Abstracts.Bots;

namespace Telegram.Bot.Framework.Bots
{
    /// <summary>
    /// 添加一个自定义的配置
    /// </summary>
    [DebuggerDisplay("添加自定义服务注册")]
    internal class TelegramServicesSetting : ITelegramPartCreator
    {
        private readonly Action<IServiceCollection, IServiceProvider> __ServiceSettingAction;
        public TelegramServicesSetting(Action<IServiceCollection, IServiceProvider> action)
        {
            __ServiceSettingAction = action;
        }

        public void AddBuildService(IServiceCollection services)
        {

        }

        public void Build(IServiceCollection services, IServiceProvider builderService)
        {
            __ServiceSettingAction(services, builderService);
        }
    }

    public static partial class TelegramBuilderExtensionMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="telegramBotBuilder"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static ITelegramBotBuilder AddServices(this ITelegramBotBuilder telegramBotBuilder, Action<IServiceCollection, IServiceProvider> action)
        {
            return telegramBotBuilder.AddTelegramPartCreator(new TelegramServicesSetting(action));
        }
    }
}
