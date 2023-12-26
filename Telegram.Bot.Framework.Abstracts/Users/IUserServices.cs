﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Bot.Framework.Abstracts.Users
{
    public interface IUserServices
    {
        public IAuthenticate UserAuthenticate { get; }
    }
}