using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Bankomat
    {
        [ScaffoldColumn(false)]
        private int id { get; set; }
        [Required]
        private string Ime { get; set; }
        [Required]
        private Adresa Adresa { get; set; }

    }
}
