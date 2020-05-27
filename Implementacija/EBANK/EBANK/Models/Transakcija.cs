using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Transakcija
    {
       [ScaffoldColumn(false)]
        private int Id { get; set; }
        private DateTime vrijeme { get; set; }
        private Racun saRacuna { get; set; }
        private Racun naRacun { get; set; }
        private float Iznos { get; set; }
        private VrstaTransakcije VrstaTransakcije { get; set; }
        private NacinTransakcije NacinTransakcije { get; set; }

    }
}
