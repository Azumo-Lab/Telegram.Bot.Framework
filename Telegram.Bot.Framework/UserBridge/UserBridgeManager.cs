﻿//  <Telegram.Bot.Framework>
//  Copyright (C) <2022, 2023>  <Azumo-Lab> see <https://github.com/Azumo-Lab/Telegram.Bot.Framework/>
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
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstract;

namespace Telegram.Bot.Framework.UserBridge
{
    /// <summary>
    /// 桥管理器的一种实现
    /// TODO:暂时未实现功能
    /// </summary>
    internal class UserBridgeManager : IUserBridgeManager
    {
        private readonly IServiceProvider serviceProvider;

        public UserBridgeManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IUserBridge CreateUserBridge(TelegramUser targetTelegramUser)
        {
            throw new NotImplementedException();
        }

        public void Dispose(IUserBridge userBridge)
        {
            throw new NotImplementedException();
        }

        public IUserBridge GetUserBridge(TelegramUser telegramUser)
        {
            throw new NotImplementedException();
        }

        public bool HasUserBrige(TelegramUser telegramUser)
        {
            throw new NotImplementedException();
        }
    }
}
