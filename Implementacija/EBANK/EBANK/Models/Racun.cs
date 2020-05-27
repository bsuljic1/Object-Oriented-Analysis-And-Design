using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Racun
    {
        private int Id{ get; set; }
        private float StanjeRacuna{ get; set; }

        private VrstaRacuna vrstaRacuna { get; set; }
        private Klijent klijent { get; set; }
    }
}
