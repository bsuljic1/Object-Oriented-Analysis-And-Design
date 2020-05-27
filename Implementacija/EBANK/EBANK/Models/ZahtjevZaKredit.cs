using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class ZahtjevZaKredit : KreditBaza
    {
        [Required]
        public String NamjenaKredita { get; set; }

        [Required]
        public float MjesecniPrihodi { get; set; }

        [Required]
        public float ProsjecniTroskoviDomacinstva { get; set; }

        [Required]
        public String NazivRadnogMjesta { get; set; }

        [Required]
        public String NazivPoslodavca { get; set; }

        [Required]
        public int RadniStaz { get; set; }

        [Required]
        public int BrojNekretnina { get; set; }

        [Required]
        public float BrojNeplacenihDugova { get; set; }

        [Required]
        public StatusZahtjevaZaKredit StatusKredita { get; set; }
    }
}