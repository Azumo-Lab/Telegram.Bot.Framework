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

namespace Telegram.Bot.Framework.Abstracts.Exec;

/// <summary>
/// Bot执行前执行的任务接口
/// </summary>
/// <remarks>
/// 用于执行环境配置等
/// </remarks>
public interface IStartExec
{
    /// <summary>
    /// 开始执行
    /// </summary>
    /// <param name="bot">Bot接口</param>
    /// <param name="serviceProvider">服务</param>
    /// <returns>异步执行</returns>
    public Task Exec(ITelegramBotClient bot, IServiceProvider serviceProvider);
}
