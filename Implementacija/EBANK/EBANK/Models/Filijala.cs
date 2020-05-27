using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Filijala
    {
        [ScaffoldColumn(false)]
        private int Id { get; set; }
        [Required]
        private string Ime { get; set; }
        [Required]
        private Adresa Adresa { get; set; }
        [Required]
        private string BrojTelefona { get; set; }
    }
}
