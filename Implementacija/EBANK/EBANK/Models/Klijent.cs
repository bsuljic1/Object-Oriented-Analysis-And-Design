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
        private DateTime DatumRodjenja { get; set; }
        [Required]
        private string JMBG { get; set; }
        [Required]
        private string BrojTelefona { get; set; }
        [Required]
        private string BrojLicneKarte { get; set; }
        [Required]
        private Adresa adresa { get; set; }
        [Required]
        private string zanimanje { get; set; }
    }
}
