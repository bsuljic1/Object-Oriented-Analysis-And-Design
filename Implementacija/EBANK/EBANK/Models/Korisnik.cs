using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public abstract class Korisnik
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }
    }
}
