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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstract.Sessions;
using Telegram.Bot.Framework.Controller.Attribute;
using Telegram.Bot.Framework.ExtensionMethods;

namespace Telegram.Bot.Channel.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HelloWorld : TelegramController
    {
        [BotCommand("Test")]
        public async Task Test()
        {
            string command = Session.GetCommand();
            await Session.SendTextMessageAsync($"你发送的是{command}");
        }

        [BotCommand("SayHello")]
        public async Task Test2([Param(Message = "你想说什么？")]string str, [Param(Message = "下一句你想说什么")]string str2)
        {
            await Session.SendTextMessageAsync($"你的第一句：{str}。你的第二句：{str2}。");
        }
    }
}
