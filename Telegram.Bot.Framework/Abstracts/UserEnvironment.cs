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

using Telegram.Bot.Framework.Abstracts.Bots;
using Telegram.Bot.Framework.Abstracts.Controller;
using Telegram.Bot.Framework.Abstracts.Users;
using Telegram.Bot.Framework.Pipeline;
using Telegram.Bot.Framework.Pipeline.Abstracts;
using Telegram.Bot.Framework.Pipelines;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Framework.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    internal class UserEnvironment : ITelegramService
    {
        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="services"></param>
        public void AddServices(IServiceCollection services)
        {
            _ = services.AddScoped(x =>
            {
                return PipelineFactory.CreateIPipelineBuilder<(TGChat tGChat, IControllerContext controllerContext)>()
                    .AddProcedure(new ProcessControllerAuthenticate())
                    .AddProcedure(new ProcessControllerInvoke())
                    .CreatePipeline(UpdateType.Message)
                    .BuilderPipelineController();
            });
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        public static async Task InvokeAsync(TGChat chat)
        {
            IServiceProvider serviceProvider = chat.UserService;

            IControllerContext controllerContext = serviceProvider.GetService<IControllerContext>();

            // 获取指令
            IControllerInvoker controllerInvoker = serviceProvider.GetService<IControllerInvoker>();
            controllerContext.BotCommand = controllerInvoker.GetCommand(chat);

            IPipelineController<(TGChat tGChat, IControllerContext controllerContext)> pipelineController
                = serviceProvider.GetService<IPipelineController<(TGChat tGChat, IControllerContext controllerContext)>>();

            _ = await pipelineController.SwitchTo(chat.Type, (chat, controllerContext));
        }
    }
}
