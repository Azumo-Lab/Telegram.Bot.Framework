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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstract.Middlewares;
using Telegram.Bot.Framework.Abstract.Sessions;
using Telegram.Bot.Framework.InternalImplementation.Sessions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Framework.Helper;

namespace Telegram.Bot.Framework.MiddlewarePipelines
{
    /// <summary>
    /// 中间件流水线的抽象执行类
    /// </summary>
    public abstract class AbstractMiddlewarePipeline : IMiddlewarePipeline
    {
        private readonly IServiceProvider __ServiceProvider;
        private readonly IPipelineController __PipelineController;
        private IPipelineBuilder __PipelineBuilder;

        /// <summary>
        /// 执行的类型
        /// </summary>
        public abstract UpdateType InvokeType { get; }
        private string _InvokeTypeString;
        private string InvokeTypeStr
        {
            get
            {
                if (_InvokeTypeString.IsNullOrEmpty())
                    _InvokeTypeString = InvokeType.ToString();
                return _InvokeTypeString;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ServiceProvider">服务提供</param>
        public AbstractMiddlewarePipeline(IServiceProvider ServiceProvider)
        {
            __ServiceProvider = ServiceProvider;

            __PipelineBuilder = __ServiceProvider.GetRequiredService<IPipelineBuilder>();
            __PipelineController = __ServiceProvider.GetRequiredService<IPipelineController>();
            __PipelineController.AddPipeline(InvokeTypeStr, __PipelineBuilder);

            AddMiddlewareHandleTemplate(__ServiceProvider);
        }

        /// <summary>
        /// 添加一个模板方法
        /// </summary>
        /// <param name="ServiceProvider">服务提供</param>
        private void AddMiddlewareHandleTemplate(IServiceProvider ServiceProvider)
        {
            List<IMiddlewareTemplate> middlewareTemplates = ServiceProvider.GetServices<IMiddlewareTemplate>()?.ToList() ?? new List<IMiddlewareTemplate>();

            middlewareTemplates.ForEach(x => x.BeforeAddMiddlewareHandles(ServiceProvider));

            AddMiddlewareHandles(ServiceProvider);

            middlewareTemplates.ForEach(x => x.AfterAddMiddlewareHandles(ServiceProvider));
        }

        /// <summary>
        /// 添加中间件，创建中间件流水线
        /// </summary>
        /// <param name="ServiceProvider">DI服务</param>
        protected virtual void AddMiddlewareHandles(IServiceProvider ServiceProvider) 
        { 
            
        }

        /// <summary>
        /// 用于向流水线中添加中间件
        /// </summary>
        protected virtual void AddMiddleware<T>() where T : IMiddleware
        {
            __PipelineBuilder.AddMiddleware<T>();
        }

        /// <summary>
        /// 执行这个流水线
        /// </summary>
        /// <param name="context">访问的请求对话</param>
        /// <returns>异步可等待的Task</returns>
        public async Task Execute(ITelegramSession Session)
        {
            await InvokeAction(Session);

            __PipelineController.ChangePipeline(InvokeTypeStr);
            await __PipelineController.Next(Session);
        }

        /// <summary>
        /// 每次执行前的前置执行操作
        /// </summary>
        /// <param name="context">访问的请求对话</param>
        /// <returns>无</returns>
        protected virtual async Task InvokeAction(ITelegramSession Session)
        {
            await Task.CompletedTask;
        }
    }
}
