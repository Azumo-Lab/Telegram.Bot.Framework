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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot.Framework.InternalFramework.Models;
using Telegram.Bot.Framework.InternalFramework.TypeConfigs.Abstract;
using Telegram.Bot.Framework.TelegramAttributes;

namespace Telegram.Bot.Framework.InternalFramework.TypeConfigs.AttributeAnalyzes
{
    /// <summary>
    /// 
    /// </summary>
    internal class DefaultMessageTypeAttributeAnalyzes : IAttributeAnalyze
    {
        public Type AttributeType => typeof(DefaultMessageTypeAttribute);

        public Attribute Attribute { set; private get; }

        public CommandInfos Analyze(CommandInfos commandInfos, IAnalyze analyze)
        {
            commandInfos.CommandMethod = (MethodInfo)analyze.GetMember();
            commandInfos.MessageType = ((DefaultMessageTypeAttribute)Attribute).MessageType;
            commandInfos.Controller = commandInfos.CommandMethod.DeclaringType;
            if (commandInfos.CommandMethod.GetParameters().Any())
                throw new ArgumentException($"非常抱歉，本框架暂时不支持具有参数的方法");

            //TODO:未来有支持多个参数的计划
            /*
             * 如下面的例子：
             * [DefaultMessageType(Message)]
             * public Task Test1(Photo photo){}
             * 
             * [DefaultMessageType(Message)]
             * public task Test1(string str){}
             */

            return commandInfos;
        }

        public ICustomAttributeProvider GetMember()
        {
            return default;
        }
    }
}
