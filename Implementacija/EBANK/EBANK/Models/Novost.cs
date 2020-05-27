using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Novost
    {
        private int Id { get; set; }

        private DateTime vrijemeDodavanja { get; set; }

        [Required]
        private string Naslov { get; set; }

        [Required]
        private string Sadrzaj { get; set; }
        
        [Required]
        private bool prikazana { get; set; }

    }
}
