﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram.Bot.Framework.Language.Languages
{
    internal class Chinese : BaseLanguage
    {
        protected override void LoadLanguage()
        {
            this[ItemKey.StartInfo] = "开始信息啦";
        }
    }
}