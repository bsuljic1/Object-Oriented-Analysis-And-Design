using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.FilijaleBankomatiRepository;
using EBANK.Models.AdministratorRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class AdministratorBankomatiController : Controller
    {
        private FilijaleBankomatiProxy _filijaleBankomati;
        private IAdministratori _administratori;
        private Korisnik korisnik;
        private OOADContext Context;

        public AdministratorBankomatiController(OOADContext context)
        {
            _filijaleBankomati = new FilijaleBankomatiProxy(context);
            _administratori = new AdministratoriProxy(context);
            Context = context;
        }

        // GET: Bankomat
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;

            return View(await _filijaleBankomati.DajSveBankomate());
        }

        // GET: Bankomat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);

            @ViewData["Ime"] = korisnik.Ime;
            if (id == null)
            {
                return NotFound();
            }

            var bankomat = await _filijaleBankomati.DajBankomat(id);
            if (bankomat == null)
            {
                return NotFound();
            }

            return View(bankomat);
        }

        // GET: Bankomat/Create
        public async Task<IActionResult> CreateAsync()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;
            return View();
        }

        // POST: Bankomat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Adresa")] Bankomat bankomat)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;
            if (ModelState.IsValid)
            {
                await _filijaleBankomati.DodajBankomat(bankomat);
                return RedirectToAction(nameof(Index));
            }
            return View(bankomat);
        }

        // GET: Bankomat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;
            if (id == null)
            {
                return NotFound();
            }

            var bankomat = await _filijaleBankomati.DajBankomat(id);
            if (bankomat == null)
            {
                return NotFound();
            }
            return View(bankomat);
        }

        // POST: Bankomat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Adresa")] Bankomat bankomat)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;

            if (id != bankomat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _filijaleBankomati.UrediBankomat(bankomat);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankomatExists(bankomat.Id))
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
            return View(bankomat);
        }

        // GET: Bankomat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;
            if (id == null)
            {
                return NotFound();
            }

            var bankomat = await _filijaleBankomati.DajBankomat(id);
            if (bankomat == null)
            {
                return NotFound();
            }

            return View(bankomat);
        }

        // POST: Bankomat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);
            @ViewData["Ime"] = korisnik.Ime;
            await _filijaleBankomati.UkloniBankomat(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BankomatExists(int id)
        {
            return _filijaleBankomati.DaLiPostojiBankomat(id);
        }
    }
}
