using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Kredit:KreditBaza
    {
        public float IsplaceniIznos {get; set;}
        public DateTime PocetakOtpate { get; set; }

        public StatusKredita StatusKredita { get; set; }
}
}
