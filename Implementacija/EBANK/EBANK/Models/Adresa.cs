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
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Naziv { get; set; }
    }
}
