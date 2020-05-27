using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Klijent : Korisnik
    {
        private DateTime DatumRodjenja { get; set; }
        private string JMBG { get; set; }
        private string BrojTelefona { get; set; }
        private string BrojLicneKarte { get; set; }
        private Adresa adresa { get; set; }
        private string zanimanje { get; set; }
    }
}
