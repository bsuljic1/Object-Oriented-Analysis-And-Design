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
        private float Latitude { get; set; }
        private float Longitude { get; set; }
        private string Naziv { get; set; }
    }
}
