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
        [Display(Name = "Početak otplate")]
        public DateTime PocetakOtpate { get; set; }
    }
}
