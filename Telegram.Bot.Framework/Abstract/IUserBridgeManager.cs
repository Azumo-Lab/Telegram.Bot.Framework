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

namespace Telegram.Bot.Framework.Abstract
{
    /// <summary>
    /// 桥管理器
    /// </summary>
    internal interface IUserBridgeManager
    {
        /// <summary>
        /// 向目标用户建立通信桥
        /// </summary>
        /// <param name="telegramUser">用户1</param>
        /// <param name="targetTelegramUser">用户2</param>
        /// <returns></returns>
        IUserBridge CreateUserBridge(TelegramUser targetTelegramUser);

        /// <summary>
        /// 销毁一个用户桥
        /// </summary>
        /// <param name="userBridge"></param>
        void Dispose(IUserBridge userBridge);

        /// <summary>
        /// 目标用户是否已经建立了通信桥
        /// </summary>
        /// <param name="telegramUser"></param>
        /// <returns></returns>
        bool HasUserBrige(TelegramUser telegramUser);

        /// <summary>
        /// 获取指定用户的桥
        /// </summary>
        /// <param name="telegramUser"></param>
        /// <returns></returns>
        IUserBridge GetUserBridge(TelegramUser telegramUser);
    }
}
