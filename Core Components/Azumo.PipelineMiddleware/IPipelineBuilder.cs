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

namespace Azumo.PipelineMiddleware;

/// <summary>
/// 流水线建造器接口
/// </summary>
/// <typeparam name="TInput">流水线处理数据类型</typeparam>
public interface IPipelineBuilder<TInput>
{
    /// <summary>
    /// 使用中间件
    /// </summary>
    /// <param name="middleware"></param>
    /// <param name="middlewareInsertionMode"></param>
    /// <returns></returns>
    public IPipelineBuilder<TInput> Use(IMiddleware<TInput> middleware, MiddlewareInsertionMode middlewareInsertionMode = MiddlewareInsertionMode.EndOfPhase);

    /// <summary>
    /// 使用流水线执行过滤
    /// </summary>
    /// <param name="invokeFilter"></param>
    /// <returns></returns>
    public IPipelineBuilder<TInput> Use(IPipelineInvokeFilter<TInput> invokeFilter);

    /// <summary>
    /// 使用流水线过滤器
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public IPipelineBuilder<TInput> Use(IPipelineFilter<TInput> filter);

    /// <summary>
    /// 创建一个新的流水线
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IPipelineBuilder<TInput> NewPipeline(object name);

    /// <summary>
    /// 开始创建流水线控制器
    /// </summary>
    /// <returns></returns>
    public IPipelineController<TInput> Build();
}
