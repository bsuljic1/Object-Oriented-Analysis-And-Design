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
        public int Id{ get; set; }

        [Required]
        public float StanjeRacuna{ get; set; }

        [Required]
        public VrstaRacuna vrstaRacuna { get; set; }

        //[Required]
        //public Klijent klijent { get; set; }
    }
}
