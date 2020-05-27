using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Kredit:KreditBaza
    {
        private float IsplaceniIznos {get; set;}
        private DateTime PocetakOtpate { get; set; }

        private StatusKredita StatusKredita { get; set; }
}
}
