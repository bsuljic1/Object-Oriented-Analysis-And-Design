using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Kredit:KreditBaza
    {
        [Display(Name = "Isplaćeni iznos")]
        public float IsplaceniIznos {get; set;}
        [Display(Name = "Početak otplate")]
        public DateTime PocetakOtpate { get; set; }
        [Display(Name = "Status kredita")]
        public StatusKredita StatusKredita { get; set; }
}
}
