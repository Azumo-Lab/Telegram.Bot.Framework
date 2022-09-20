﻿//  <Telegram.Bot.Framework>
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot.Framework.InternalFramework.InterFaces;

namespace Telegram.Bot.Framework.InternalFramework
{
    /// <summary>
    /// 
    /// </summary>
    internal class ActionCallBack : IAction, IHandleSort
    {
        public int Sort => 150;

        public async Task Invoke(TelegramContext context, IServiceScope UserScope, IServiceScope OneTimeScope, ActionHandle NextHandle)
        {
            if (context.Update.Type == Types.Enums.UpdateType.CallbackQuery)
            {
                ICallBackManager callBackManger = UserScope.ServiceProvider.GetService<ICallBackManager>();

                Action<TelegramContext, IServiceScope> action = callBackManger.GetCallBack(context.Update.CallbackQuery.Data);

                if (action != null)
                {
                    action.Invoke(context, UserScope);
                    return;
                }
            }

            await NextHandle(context, UserScope, OneTimeScope);
        }
    }
}