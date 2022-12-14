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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Telegram.Bot.Framework.InternalFramework.FrameworkHelper
{
    /// <summary>
    /// 创建委托
    /// </summary>
    internal static class DelegateHelper
    {
        #region 初始化
        private static readonly Dictionary<int, Type> ActionTypes = new Dictionary<int, Type>();
        private static readonly Dictionary<int, Type> FuncTypes = new Dictionary<int, Type>();
        static DelegateHelper()
        {
            ActionTypes.Add(0, typeof(Action));
            ActionTypes.Add(1, typeof(Action<>));
            ActionTypes.Add(2, typeof(Action<,>));
            ActionTypes.Add(3, typeof(Action<,,>));
            ActionTypes.Add(4, typeof(Action<,,,>));
            ActionTypes.Add(5, typeof(Action<,,,,>));
            ActionTypes.Add(6, typeof(Action<,,,,,>));
            ActionTypes.Add(7, typeof(Action<,,,,,,>));
            ActionTypes.Add(8, typeof(Action<,,,,,,,>));
            ActionTypes.Add(9, typeof(Action<,,,,,,,,>));
            ActionTypes.Add(10, typeof(Action<,,,,,,,,,>));
            ActionTypes.Add(11, typeof(Action<,,,,,,,,,,>));
            ActionTypes.Add(12, typeof(Action<,,,,,,,,,,,>));
            ActionTypes.Add(13, typeof(Action<,,,,,,,,,,,,>));
            ActionTypes.Add(14, typeof(Action<,,,,,,,,,,,,,>));
            ActionTypes.Add(15, typeof(Action<,,,,,,,,,,,,,,>));
            ActionTypes.Add(16, typeof(Action<,,,,,,,,,,,,,,,>));

            FuncTypes.Add(0, typeof(Func<>));
            FuncTypes.Add(1, typeof(Func<,>));
            FuncTypes.Add(2, typeof(Func<,,>));
            FuncTypes.Add(3, typeof(Func<,,,>));
            FuncTypes.Add(4, typeof(Func<,,,,>));
            FuncTypes.Add(5, typeof(Func<,,,,,>));
            FuncTypes.Add(6, typeof(Func<,,,,,,>));
            FuncTypes.Add(7, typeof(Func<,,,,,,,>));
            FuncTypes.Add(8, typeof(Func<,,,,,,,,>));
            FuncTypes.Add(9, typeof(Func<,,,,,,,,,>));
            FuncTypes.Add(10, typeof(Func<,,,,,,,,,,>));
            FuncTypes.Add(11, typeof(Func<,,,,,,,,,,,>));
            FuncTypes.Add(12, typeof(Func<,,,,,,,,,,,,>));
            FuncTypes.Add(13, typeof(Func<,,,,,,,,,,,,,>));
            FuncTypes.Add(14, typeof(Func<,,,,,,,,,,,,,,>));
            FuncTypes.Add(15, typeof(Func<,,,,,,,,,,,,,,,>));
            FuncTypes.Add(16, typeof(Func<,,,,,,,,,,,,,,,,>));
        }
        #endregion

        /// <summary>
        /// 创建一个委托
        /// </summary>
        /// <param name="methodInfo">方法</param>
        /// <param name="instance">新的实例</param>
        /// <returns></returns>
        public static Delegate CreateDelegate(MethodInfo methodInfo, object instance)
        {
            ThrowHelper.ThrowIfNull(methodInfo, nameof(methodInfo));

            List<Type> T = methodInfo.GetParameters().Select(x => x.ParameterType).ToList();
            Type returnType = methodInfo.ReturnType;

            Type delegateType = null;
            if (returnType.FullName == typeof(void).FullName)
            {
                delegateType = ActionTypes[T.Count];
                delegateType = delegateType.MakeGenericType(T.ToArray());
            }
            else
            {
                delegateType = FuncTypes[T.Count];
                T.Add(returnType);
                delegateType = delegateType.MakeGenericType(T.ToArray());
            }

            if (instance == null)
                return Delegate.CreateDelegate(delegateType, methodInfo);
            else
                return Delegate.CreateDelegate(delegateType, instance, methodInfo);
        }
    }
}
