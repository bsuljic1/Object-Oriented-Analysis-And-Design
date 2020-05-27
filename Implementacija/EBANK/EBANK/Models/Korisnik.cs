using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Korisnik
    {
        private int Id { get; set; }
        private string Ime { get; set; }
        private string Prezime { get; set; }
        private string KorisnickoIme { get; set; }
        private string Lozinka { get; set; }
    }
}
