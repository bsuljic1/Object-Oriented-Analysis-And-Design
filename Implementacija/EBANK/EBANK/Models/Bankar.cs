﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Bankar : Korisnik
    {
        public Adresa MjestoZaposlenja { get; set; }
    }
}
