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

namespace EBANK.Controllers
{
    public class KlijentZahtjevZaKreditController : Controller
    {
        private IZahtjeviZaKredit _zahtjevi;

        public KlijentZahtjevZaKreditController(OOADContext context)
        {
            _zahtjevi = new ZahtjeviZaKreditProxy(context);
        }


        // GET: KlijentZahtjevZaKredit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KlijentZahtjevZaKredit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamjenaKredita,MjesecniPrihodi,ProsjecniTroskoviDomacinstva,NazivRadnogMjesta,NazivPoslodavca,RadniStaz,BrojNekretnina,BracnoStanje,SupruznikIme,SupruznikPrezime,SupruznikZanimanje,ImaNeplacenihDugova,BrojNeplacenihDugova,StatusZahtjeva,Iznos,KamatnaStopa,RokOtplate")] ZahtjevZaKredit zahtjevZaKredit)
        {
            if (ModelState.IsValid)
            {
                await _zahtjevi.PodnesiZahtjevZaKredit(zahtjevZaKredit);
                return View("~/Views/KlijentHome/Index.cshtml");
            }
            return View(zahtjevZaKredit);
        }

        
    }
}
