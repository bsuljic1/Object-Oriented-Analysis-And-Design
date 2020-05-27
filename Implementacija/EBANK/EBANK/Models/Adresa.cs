using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Adresa
    {
        [ScaffoldColumn(false)]
        private int Id { get; set; }
        [Required]
        private float Latitude { get; set; }
        [Required]
        private float Longitude { get; set; }
        [Required]
        private string Naziv { get; set; }
    }
}
