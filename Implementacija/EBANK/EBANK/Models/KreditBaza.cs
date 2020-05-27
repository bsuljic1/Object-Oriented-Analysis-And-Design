using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class KreditBaza
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public DateTime PocetakOtpate { get; set; }
        public StatusKredita StatusKredita { get; set; }

    }
}
