using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.TransakcijaRepository;
using EBANK.Utils;
using EBANK.Models.RacunRepository;

namespace EBANK.Controllers
{
    public class KlijentTransakcijaController : Controller
    {
         private TransakcijeProxy _transakcije;
        private OOADContext Context;
        private Korisnik korisnik;
        private RacuniProxy _racuni;

        public KlijentTransakcijaController(OOADContext context)
        {
            _transakcije = new TransakcijeProxy(context);
            _racuni = new RacuniProxy(context);
            Context = context;
            
        }

        // GET: KlijentTransakcija
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);
            return View(await _transakcije.DajSveTransakcije());
        }

        // GET: KlijentTransakcija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _transakcije.DajTransakciju(id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return View(transakcija);
        }

        // GET: KlijentTransakcija/Create
        public async Task<IActionResult> Create()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

           _transakcije.Pristupi(korisnik);
            _racuni.Pristupi(korisnik);

            ViewData["racuni"] = await _racuni.DajSveRacuneKlijenta(korisnik.Id);
            return View();
        }

        // POST: KlijentTransakcija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vrijeme,Iznos,VrstaTransakcije,NacinTransakcije")] Transakcija transakcija)
        {

            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);
            _racuni.Pristupi(korisnik);

            if (ModelState.IsValid)
            {
                await _transakcije.Uplati(transakcija);
                return RedirectToAction(nameof(Index));
            }

            return View(transakcija);
        }

        
       

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
