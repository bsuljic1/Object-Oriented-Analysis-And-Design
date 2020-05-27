using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Klijent : Korisnik
    {
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public string JMBG { get; set; }
        [Required]
        public string BrojTelefona { get; set; }
        [Required]
        public string BrojLicneKarte { get; set; }
        [Required]
        public Adresa Adresa { get; set; }
        [Required]
        public string Zanimanje { get; set; }
    }
}
