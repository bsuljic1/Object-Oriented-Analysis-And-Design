using EBANK.Models.FilijaleBankomatiRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Bankomat : IMapObjekat
    {
        public Bankomat(string ime, Adresa adresa)
        {
            Ime = ime;
            Adresa = adresa;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public Adresa Adresa { get; set; }

        public string DajVrstu()
        {
            return "Bankomat";
        }
    }
}
