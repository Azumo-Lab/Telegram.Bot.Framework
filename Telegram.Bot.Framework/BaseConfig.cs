﻿//  < Telegram.Bot.Framework >
//  Copyright (C) <2022>  <Sokushu> see <https://github.com/sokushu/Telegram.Bot.Net/>
//
//  This program is free software: you can redistribute it and/or modify
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
using System.Reflection;
using System.Text;
using Telegram.Bot.Framework.ControllerManger;
using Telegram.Bot.Framework.TelegramAttributes;
using Telegram.Bot.Framework.TelegramException;

namespace Telegram.Bot.Framework
{
    internal class BaseConfig : IConfig
    {

        private readonly List<IConfig> setUps;

        public BaseConfig(List<IConfig> setUps)
        {
            this.setUps = setUps;
        }

        public void Config(IServiceCollection telegramServices)
        {
            telegramServices.AddTransient<ITelegramRouteUserController, TelegramRouteUserController>();
            
            telegramServices.AddControllers();

            setUps.ForEach(x => x.Config(telegramServices));
        }
    }

    public static class ServiceCollectionEx
    {
        public static void AddControllers(this IServiceCollection services)
        {
            Type basetype = typeof(TelegramController);
            List<Type> types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => basetype.IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface).ToList();
            Dictionary<string, Type> Command_ControllerMap = new Dictionary<string, Type>();
            Dictionary<string, MethodInfo> Command_MethodMap = new Dictionary<string, MethodInfo>();
            foreach (Type item in types)
            {
                services.AddScoped(item);

                var methods = item.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in methods)
                {
                    CommandAttribute attr = (CommandAttribute)Attribute.GetCustomAttribute(method, typeof(CommandAttribute));
                    if (attr == null)
                        continue;
                    if (Command_ControllerMap.ContainsKey(attr.CommandName))
                        throw new RepeatedCommandException(attr.CommandName);
                    Command_ControllerMap.Add(attr.CommandName, item);
                    Command_MethodMap.Add(attr.CommandName, method);

                    var methodParams = method.GetParameters().ToList();
                    foreach (var para in methodParams)
                    {

                    }
                }
            }
            
            ControllersManger controllersManger = new ControllersManger(Command_ControllerMap);
            DelegateManger delegateManger = new DelegateManger(Command_MethodMap);
            ParamManger paramManger = new ParamManger();

            services.AddSingleton<IControllersManger>(controllersManger);
            services.AddSingleton<IDelegateManger>(delegateManger);
            services.AddScoped<IParamManger, ParamManger>();
        }
    }
}