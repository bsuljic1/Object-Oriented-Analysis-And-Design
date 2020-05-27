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
        public int Id { get; set; }

        [Required]
        public DateTime vrijeme { get; set; }

        [Required]
        public Racun saRacuna { get; set; }

        [Required]
        public Racun naRacun { get; set; }

        [Required]
        public float Iznos { get; set; }

        [Required]
        public VrstaTransakcije VrstaTransakcije { get; set; }

        [Required]
        public NacinTransakcije NacinTransakcije { get; set; }

    }
}
