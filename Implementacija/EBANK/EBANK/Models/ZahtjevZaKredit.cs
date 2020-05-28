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
        [Display(Name = "Naziv Vašeg poslodavca")]
        public String NazivPoslodavca { get; set; }

        [Required]
        [Display(Name = "Ukupno radnog staža")]
        public int RadniStaz { get; set; }

        [Required]
        [Display(Name = "Broj nekretnina u vlasništvu")]
        public int BrojNekretnina { get; set; }

        
        [Required]
        [Display(Name = "Bračno stanje")]
        public BracnoStanje BracnoStanje { get; set; }

        
        [Display(Name = "Ime supružnika")]
        public string SupruznikIme { get; set; }

        [Display(Name = "Prezime supružnika")]
        public string SupruznikPrezime { get; set; }

        [Display(Name = "Zanimanje supružnika")]
        public string SupruznikZanimanje { get; set; }

        [Required]
        [Display(Name = "Imate li neplaćenih dugova?")]
        public bool ImaNeplacenihDugova { get; set; }

        [Required]
        [Display(Name = "Broj neplaćenih dugova")]
        public float BrojNeplacenihDugova { get; set; }


        [Required]
        [Display(Name = "Status zahtjeva")]
        public StatusZahtjevaZaKredit StatusZahtjeva { get; set; } = StatusZahtjevaZaKredit.Neobradjen;
    }
}