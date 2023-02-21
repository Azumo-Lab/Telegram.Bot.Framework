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
using Telegram.Bot.Framework.InternalFramework.Models;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Framework.Abstract
{
    /// <summary>
    /// 控制器管理
    /// </summary>
    internal interface IControllerManager
    {
        /// <summary>
        /// 通过指令名称 创建Controller
        /// </summary>
        /// <param name="CommandName">指令名称</param>
        /// <returns>控制器</returns>
        public TelegramController CreateController(string CommandName);

        /// <summary>
        /// 通过消息类型 创建Controller
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <returns>控制器</returns>
        public TelegramController CreateController(MessageType messageType);

        /// <summary>
        /// 通过指令名称获取 CommandInfos
        /// </summary>
        /// <param name="CommandName">指令名称</param>
        /// <returns>指令的信息</returns>
        public CommandInfos GetCommandInfo(string CommandName);
    }
}
