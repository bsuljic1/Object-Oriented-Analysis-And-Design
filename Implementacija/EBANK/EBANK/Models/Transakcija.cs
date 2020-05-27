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

        [Required]
        private DateTime vrijeme { get; set; }

        [Required]
        private Racun saRacuna { get; set; }

        [Required]
        private Racun naRacun { get; set; }

        [Required]
        private float Iznos { get; set; }

        [Required]
        private VrstaTransakcije VrstaTransakcije { get; set; }

        [Required]
        private NacinTransakcije NacinTransakcije { get; set; }

    }
}
