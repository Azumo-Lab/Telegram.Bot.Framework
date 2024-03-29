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

namespace Telegram.Bot.Framework.Abstract
{
    /// <summary>
    /// Command 指令管理器
    /// </summary>
    public interface ICommandManager
    {
        #region 增
        /// <summary>
        /// 注册指令，将指令注册到Telegram
        /// </summary>
        void RegisterCommand(string commandName, string commandInfo);
        #endregion

        #region 删
        /// <summary>
        /// 删除一个Command
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        void RemoveCommand(string commandName);
        #endregion

        #region 改
        /// <summary>
        /// 从删除的当中恢复一个Command
        /// </summary>
        /// <param name="commandName"></param>
        void RestoreCommand(string commandName);
        #endregion

        #region 查
        /// <summary>
        /// 系统中是否具有此Command
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        bool ContainsCommand(string commandName);

        /// <summary>
        /// 获取全部的Command的字符串
        /// </summary>
        /// <returns></returns>
        string GetCommandInfoString();

        /// <summary>
        /// 获取全部的Command的字典类型
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetCommandInfos();
        #endregion
    }
}
