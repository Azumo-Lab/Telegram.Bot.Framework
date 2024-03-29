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
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstract;
using Telegram.Bot.Framework.TelegramAttributes;

namespace Telegram.Bot.SendMessageBot.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeMenuController : TelegramController
    {
        [Command("SayHelloToAdmin", "用户桥应用演示，通过用户桥向管理员取得联系")]
        public async void SayHelloToAdmin()
        {
            await Context.SendTextMessage("正在向管理员问好...");
            await Context.SendTextMessage("正在与管理员取得联系...");

            IUserBridgeManager userBridgeManager = Context.UserScope.GetRequiredService<IUserBridgeManager>();
            IUserManager userManager = Context.UserScope.GetRequiredService<IUserManager>();

            IUserBridge userBridge = userBridgeManager.CreateUserBridge(userManager.Me, userManager.Admin.First());
            userBridge.Connect();
        }
    }
}
