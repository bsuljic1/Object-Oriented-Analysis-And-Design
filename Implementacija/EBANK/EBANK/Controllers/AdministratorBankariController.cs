using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.BankarRepository;
using System.Runtime.InteropServices;
using EBANK.Models.AdministratorRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class AdministratorBankariController : Controller
    {
        private BankariProxy _bankari;
        private IAdministratori _administratori;
        private Korisnik korisnik;
        private OOADContext Context;

        public AdministratorBankariController(OOADContext context)
        {
            _bankari = new BankariProxy(context);
            _administratori = new AdministratoriProxy(context);
            Context = context;
        }

        // GET: AdministratorBankari
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;
            return View(await _bankari.DajSveBankare());
        }

        // GET: AdministratorBankari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;

            if (id == null)
            {
                return NotFound();
            }

            var bankar = await _bankari.DajBankara(id);
            if (bankar == null)
            {
                return NotFound();
            }

            return View(bankar);
        }

        // GET: AdministratorBankari/Create
        public async Task<IActionResult> CreateAsync()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;
            return View();
        }

        // POST: AdministratorBankari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Prezime,KorisnickoIme,Lozinka,MjestoZaposlenja")] Bankar bankar)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;

            if (ModelState.IsValid)
            {
                await _bankari.DodajBankara(bankar);
                return RedirectToAction(nameof(Index));
            }
            return View(bankar);
        }

        // GET: AdministratorBankari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;

            if (id == null)
            {
                return NotFound();
            }

            var bankar = await _bankari.DajBankara(id);
            if (bankar == null)
            {
                return NotFound();
            }
            return View(bankar);
        }

        // POST: AdministratorBankari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,KorisnickoIme,Lozinka,MjestoZaposlenja")] Bankar bankar)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;

            if (id != bankar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bankari.UrediBankara(bankar);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankarExists(bankar.Id))
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
            return View(bankar);
        }

        // GET: AdministratorBankari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;

            if (id == null)
            {
                return NotFound();
            }

            var bankar = await _bankari.DajBankara(id);
            if (bankar == null)
            {
                return NotFound();
            }

            return View(bankar);
        }

        // POST: AdministratorBankari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _bankari.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;

            await _bankari.UkloniBankara(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BankarExists(int id)
        {
            return _bankari.DaLiPostojiBankar(id);
        }
    }
}
