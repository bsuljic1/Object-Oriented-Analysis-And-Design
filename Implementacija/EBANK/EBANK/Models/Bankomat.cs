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
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public Adresa Adresa { get; set; }
    }
}
