﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.ViewModels
{
    public class SendMailViewModel
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }

    }
}
