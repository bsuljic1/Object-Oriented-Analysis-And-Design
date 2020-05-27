using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Filijala
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public Adresa Adresa { get; set; }
        public string BrojTelefona { get; set; }
    }
}
