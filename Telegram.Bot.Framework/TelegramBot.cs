//  <Telegram.Bot.Framework>
//  Copyright (C) <2022>  <Azumo-Lab> see <https://github.com/Azumo-Lab/Telegram.Bot.Framework/>
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Framework.InternalFramework;
using Telegram.Bot.Framework.InternalFramework.InterFaces;
using Telegram.Bot.Framework.InternalFramework.Models;
using Telegram.Bot.Framework.TelegramException;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Framework
{
    public class TelegramBot
    {
        private readonly IServiceCollection telegramServiceCollection;
        private readonly IServiceProvider serviceProvider;

        private bool Running = false;           //多次启动的Flag
        private bool StopFlag = false;          //停止Flag
        private CancellationTokenSource cts;    //CancellationTokenSource

        /// <summary>
        /// 创建 & 设置Bot
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="setUp"></param>
        /// <param name="BotName"></param>
        internal TelegramBot(IServiceProvider serviceProvider)
        {
            BotInfos infos = serviceProvider.GetService<BotInfos>();

            telegramServiceCollection = new ServiceCollection();

            List<IConfig> configs = serviceProvider.GetServices<IConfig>().ToList();
            configs.ForEach(x => 
            {
                x.Config(telegramServiceCollection);
            });

            this.serviceProvider = telegramServiceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// 启动Bot
        /// </summary>
        /// <param name="Wait">等待</param>
        public Task Start()
        {
            lock (this)
                if (Running)
                    throw new TooManyExecutionsException("Too Many Executions");
            Running = true;

            cts = serviceProvider.GetService<CancellationTokenSource>();
            ITelegramBotClient botClient = serviceProvider.GetService<ITelegramBotClient>();

            ReceiverOptions receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            IUpdateHandler updateHandler = serviceProvider.GetService<IUpdateHandler>();

            // 开始执行
            Task botTask = Task.Run(async () => 
            {
                botClient.StartReceiving(
                    updateHandler: updateHandler.HandleUpdateAsync,
                    pollingErrorHandler: updateHandler.HandlePollingErrorAsync,
                    receiverOptions: receiverOptions,
                    cancellationToken: cts.Token
                );

                User me = await botClient.GetMeAsync();

                Console.WriteLine($"Start listening for @{me.Username}");

                while (!StopFlag)
                    await Task.Delay(500);

                cts.Cancel();
            });

            return botTask;
        }

        /// <summary>
        /// 停止执行Bot
        /// </summary>
        public void Stop()
        {
            StopFlag = true;
        }
    }
}
