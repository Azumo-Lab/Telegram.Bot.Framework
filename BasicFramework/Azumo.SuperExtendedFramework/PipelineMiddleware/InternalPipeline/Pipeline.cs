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

namespace Azumo.SuperExtendedFramework.PipelineMiddleware.InternalPipeline;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TInput"></typeparam>
/// <typeparam name="TResult"></typeparam>
/// <param name="middleware"></param>
internal class Pipeline<TInput, TResult>(PipelineMiddlewareDelegate<TInput, TResult> middleware) : IPipeline<TInput, TResult>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly PipelineMiddlewareDelegate<TInput, TResult> middleware = middleware;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public TResult Invoke(TInput input) =>
        middleware.Invoke(input);
}