using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Novost
    {
        public int Id { get; set; }

        public DateTime vrijemeDodavanja { get; set; }

        [Required]
        public string Naslov { get; set; }

        [Required]
        public string Sadrzaj { get; set; }
        
        [Required]
        public bool prikazana { get; set; }

    }
}
