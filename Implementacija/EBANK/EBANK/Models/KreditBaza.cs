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
        private int Id { get; set; }
        private DateTime PocetakOtpate { get; set; }
        private StatusKredita StatusKredita { get; set; }

    }
}
