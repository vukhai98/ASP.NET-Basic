﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkInASP.NET.Services
{
    public class MailSettings
    {
        public string Mail { set; get; }

        public string DisplayName { set; get; }

        public string Password { set; get; }

        public string Host { set; get; }

        public int Port { set; get; }
    }
}
