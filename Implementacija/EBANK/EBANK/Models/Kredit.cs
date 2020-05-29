using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Kredit:KreditBaza
    {
        public Kredit()
        {
            IsplaceniIznos = 0; // Set the initial value for model
            PocetakOtplate = DateTime.Now;
            StatusKredita = StatusKredita.Aktivan;
        }
        [Display(Name = "Isplaćeni iznos")]
        public float IsplaceniIznos {get; set;}
        [Display(Name = "Početak otplate")]
        public DateTime PocetakOtplate { get; set; }
        [Display(Name = "Status kredita")]
        public StatusKredita StatusKredita { get; set; }
}
}
