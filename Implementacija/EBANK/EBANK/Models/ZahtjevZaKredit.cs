using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models
{
    public class ZahtjevZaKredit : KreditBaza
    {
        [Required]
        [Display(Name = "Namjena kredita")]
        public String NamjenaKredita { get; set; }

        [Required]
        [Display(Name = "Mjesečni prihodi")]
        public float MjesecniPrihodi { get; set; }

        [Required]
        [Display(Name = "Prosječni troškovi domaćinstva")]
        public float ProsjecniTroskoviDomacinstva { get; set; }

        [Required]
        [Display(Name = "Naziv radnog mjesta")]
        public String NazivRadnogMjesta { get; set; }

        [Required]
        [Display(Name = "Naziv poslodavca")]
        public String NazivPoslodavca { get; set; }

        [Required]
        [Display(Name = "Radni staž")]
        public int RadniStaz { get; set; }

        [Required]
        [Display(Name = "Broj nekretnina")]
        public int BrojNekretnina { get; set; }

        [Required]
        [Display(Name = "Broj neplaćenih dugova")]
        public float BrojNeplacenihDugova { get; set; }

        [Required]
        [Display(Name = "Status zahtjeva")]
        public StatusZahtjevaZaKredit StatusZahtjeva { get; set; }
    }
}