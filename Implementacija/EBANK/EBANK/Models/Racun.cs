using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Racun
    {
        [ScaffoldColumn(false)]
        private int Id{ get; set; }

        [Required]
        private float StanjeRacuna{ get; set; }

        [Required]
        private VrstaRacuna vrstaRacuna { get; set; }

        [Required]
        private Klijent klijent { get; set; }
    }
}
