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
        private String NamjenaKredita { get; set; }

        [Required]
        private float MjesecniPrihodi { get; set; }

        [Required]
        private float ProsjecniTroskoviDomacinstva { get; set; }

        [Required]
        private String NazivRadnogMjesta { get; set; }

        [Required]
        private String NazivPoslodavca { get; set; }

        [Required]
        private int RadniStaz { get; set; }

        [Required]
        private int BrojNekretnina { get; set; }

        [Required]
        private float BrojNeplacenihDugova { get; set; }

        [Required]
        private StatusZahtjevaZaKredit StatusKredita { get; set; }
    }
}