﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum StatusKredita
    {
        Aktivan,
        [Display(Name = "Završen")]
        Zavrsen
    }
}
