using EBANK.Models.FilijaleBankomatiRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Filijala : IMapObjekat
    {
        public Filijala(string ime, string brojTelefona, Adresa adresa)
        {
            Ime = ime;
            BrojTelefona = brojTelefona;
            Adresa = adresa;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public Adresa Adresa { get; set; }
        [Required]
        [Display(Name = "Broj telefona")]
        public string BrojTelefona { get; set; }

        public string DajVrstu()
        {
            return "Filijala";
        }
    }
}
