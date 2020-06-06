using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.KlijentRepository;
using EBANK.Models.TransakcijaRepository;
using EBANK.Models.RacunRepository;
using EBANK.Models.KreditRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class KlijentProfilController : Controller
    {
        private KlijentiProxy _klijenti;
        private OOADContext Context;
        private TransakcijeProxy _transakcije;
        private Korisnik korisnik;
        private RacuniProxy _racuni;
        private KreditiProxy _krediti;

        public KlijentProfilController(OOADContext context)
        {
            _klijenti = new KlijentiProxy(context);
            Context = context;
            _transakcije = new TransakcijeProxy(context);
            _racuni = new RacuniProxy(context);
            _krediti = new KreditiProxy(context);
        }

        // GET: KlijentProfil
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);
            _transakcije.Pristupi(korisnik);
            _krediti.Pristupi(korisnik);

            ViewData["Id"] = korisnik.Id;


            var klijent = await _klijenti.DajKlijenta(korisnik.Id);
            if (klijent == null)
            {
                return NotFound();
            }

            ViewData["transakcije"] = await _transakcije.DajTransakcije(korisnik.Id);
            ViewData["racuni"] = await _racuni.DajRacune(korisnik.Id);
            ViewData["krediti"] = await _krediti.DajSveKrediteKlijenta(korisnik.Id);

            return View(klijent);
        }


    }
}
