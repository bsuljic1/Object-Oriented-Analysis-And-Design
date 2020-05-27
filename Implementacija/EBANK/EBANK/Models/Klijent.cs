using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Klijent : Korisnik
    {
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string BrojTelefona { get; set; }
        public string BrojLicneKarte { get; set; }
        public Adresa Adresa { get; set; }
        public string Zanimanje { get; set; }
    }
}
