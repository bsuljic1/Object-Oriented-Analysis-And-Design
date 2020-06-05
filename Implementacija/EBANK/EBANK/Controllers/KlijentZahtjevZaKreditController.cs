using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.ZahtjevZaKreditRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class KlijentZahtjevZaKreditController : Controller
    {
        private OOADContext Context;
        private Korisnik korisnik;
        private ZahtjeviZaKreditProxy _zahtjevi;

        public KlijentZahtjevZaKreditController(OOADContext context)
        {
            _zahtjevi = new ZahtjeviZaKreditProxy(context);
            Context = context;
        }

        // GET: KlijentZahtjevZaKredit/Create
        public async Task<IActionResult> Create()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _zahtjevi.Pristupi(korisnik); 

            return View();
        }

        // POST: KlijentZahtjevZaKredit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamjenaKredita,MjesecniPrihodi,ProsjecniTroskoviDomacinstva,NazivRadnogMjesta,NazivPoslodavca,RadniStaz,BrojNekretnina,BracnoStanje,SupruznikIme,SupruznikPrezime,SupruznikZanimanje,ImaNeplacenihDugova,BrojNeplacenihDugova,StatusZahtjeva,Iznos,KamatnaStopa,RokOtplate")] ZahtjevZaKredit zahtjevZaKredit)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _zahtjevi.Pristupi(korisnik); 

            if (ModelState.IsValid)
            {
                await _zahtjevi.PodnesiZahtjevZaKredit(zahtjevZaKredit);
                return View("~/Views/KlijentHome/Index.cshtml");
            }
            return View(zahtjevZaKredit);
        }

        
    }
}
