﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Model
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issure { get; set; }
        public string Audince { get; set; }
        public int DurationDays { get; set; }
    }
}