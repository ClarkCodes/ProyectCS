﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEleccionReina.Entidades
{
    internal class ComboBoxItem
    {
        public string Display { get; set; }
        public int Value { get; set; }

        public override string ToString() => Display;
    }
}
