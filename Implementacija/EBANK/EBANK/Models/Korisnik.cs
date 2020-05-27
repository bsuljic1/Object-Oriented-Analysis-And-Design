using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Korisnik
    {
        [ScaffoldColumn(false)]
        private int Id { get; set; }
        [Required]
        private string Ime { get; set; }
        [Required]
        private string Prezime { get; set; }
        [Required]
        private string KorisnickoIme { get; set; }
        [Required]
        private string Lozinka { get; set; }
    }
}
