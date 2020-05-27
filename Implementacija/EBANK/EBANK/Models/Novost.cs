using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class Novost
    {
        private int Id { get; set; }
        private DateTime vrijemeDodavanja { get; set; }
        private string Naslov { get; set; }
        private string Sadrzaj { get; set; }
        private bool prikazana { get; set; }

    }
}
