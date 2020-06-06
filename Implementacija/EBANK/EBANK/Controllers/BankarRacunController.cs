using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.RacunRepository;
using EBANK.Models.KlijentRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class BankarRacunController : Controller
    {
        private RacuniProxy _racuni;
        private KlijentiProxy _klijenti;
        private OOADContext Context;
        private Korisnik korisnik;

        public BankarRacunController(OOADContext context)
        {
            _racuni = new RacuniProxy(context);
            _klijenti = new KlijentiProxy(context);
            Context = context;
        }

        // GET: BankarRacun
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            return View(await _racuni.DajSveRacune());
        }

        

        // GET: BankarRacun/Create
        public async Task<IActionResult> CreateAsync()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            return View();
        }

        // POST: BankarRacun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StanjeRacuna,VrstaRacuna,Klijent")] Racun racun)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            Klijent klijent = await _klijenti.DajKlijentaLK(racun.Klijent.BrojLicneKarte);
            if (klijent != null)
            {
                racun.Klijent = klijent;
                await _racuni.OtvoriRacun(racun);
                return RedirectToAction(nameof(Index));
            }
            return View(racun);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);


            if (id == null)
            {
                return NotFound();
            }

            var racun = await _racuni.DajRacun(id);
            if (racun == null)
            {
                return NotFound();
            }
            return View(racun);
        }

        // POST: BankarKlijent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StanjeRacuna")] Racun racun)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);

            if (id != racun.Id)
            {
                return NotFound();
            }

           
                try
                {
                    await _racuni.UrediStanjeRacuna(racun);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacunExists(racun.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }



        // GET: BankarRacun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            if (id == null)
            {
                return NotFound();
            }

            var racun = await _racuni.DajRacun(id);
            if (racun == null)
            {
                return NotFound();
            }

            return View(racun);
        }

        // POST: BankarRacun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            await _racuni.ZatvoriRacun(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RacunExists(int id)
        {
            return _racuni.DaLiPostojiRacun(id);
        }
    }
}
