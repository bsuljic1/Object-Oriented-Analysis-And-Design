using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class ZahtjevZaKredit:KreditBaza
    {
        private String NamjenaKredita{ get; set; }
        private float MjesecniPrihodi{ get; set; }

        private float ProsjecniTroskoviDomacinstva{ get; set; }
        private String NazivRadnogMjesta { get; set; }
        private String NazivPoslodavca { get; set; }

        private int RadniStaz { get; set; }
        private int BrojNekretnina { get; set; }
        private float BrojNeplacenihDugova{ get; set; }

        private StatusZahtjevaZaKredit StatusKredita { get; set; }


    }
}
