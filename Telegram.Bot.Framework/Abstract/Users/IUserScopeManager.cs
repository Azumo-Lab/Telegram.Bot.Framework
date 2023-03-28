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

namespace Telegram.Bot.Framework.Abstract.Users
{
    /// <summary>
    /// UserScope管理器
    /// </summary>
    public interface IUserScopeManager
    {
        /// <summary>
        /// 获得一个用户Scope, 如果该UserScope不存在则返回NULL
        /// </summary>
        /// <param name="telegramUser">用户</param>
        /// <returns></returns>
        IUserScope GetUserScope(TelegramUser telegramUser);

        /// <summary>
        /// 创建一个用户Scope
        /// 如果要创建的Scope已经存在，则返回已存在的Scope
        /// </summary>
        /// <param name="telegramUser">用户</param>
        /// <returns></returns>
        IUserScope CreateUserScope(TelegramUser telegramUser);
    }
}