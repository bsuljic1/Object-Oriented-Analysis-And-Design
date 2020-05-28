using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public enum RokOtplate
    {
        [Display(Name = "1 godina")]
        Trajanje_1_godina,
        [Display(Name = "5 godina")]
        Trajanje_5_godina,
        [Display(Name = "10 godina")]
        Trajanje_10_godina,
        [Display(Name = "15 godina")]
        Trajanje_15_godina,
        [Display(Name = "20 godina")]
        Trajanje_20_godina
    }
}
