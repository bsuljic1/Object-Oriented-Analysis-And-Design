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

        // GET: KlijentTransakcija/Create
        public async Task<IActionResult> Create(string area = "")
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

           _transakcije.Pristupi(korisnik);
            _racuni.Pristupi(korisnik);

            ViewData["nemaSredstava"] = area.Equals("nemaSredstava");

            ViewData["racuni"] = await _racuni.DajSveRacuneKlijenta(korisnik.Id);
            return View();
        }

        // POST: KlijentTransakcija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SaRacuna,NaRacun,Vrijeme,Iznos,VrstaTransakcije,NacinTransakcije")] Transakcija transakcija)
        {

            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);
            _racuni.Pristupi(korisnik);

            transakcija.SaRacuna = await _racuni.DajRacun(transakcija.SaRacuna.Id);
            if (transakcija.NacinTransakcije == NacinTransakcije.Interna)
                transakcija.NaRacun = await _racuni.DajRacun(transakcija.NaRacun.Id);
            else
                transakcija.NaRacun = null;

            if(transakcija.SaRacuna.StanjeRacuna < transakcija.Iznos)
                return RedirectToAction(nameof(Create), new { area = "nemaSredstava" });

            await _transakcije.Uplati(transakcija);
            return RedirectToAction("Index", "KlijentHome", new { area = "" });
        }

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
