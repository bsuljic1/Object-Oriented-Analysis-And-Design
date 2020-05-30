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

namespace EBANK.Controllers
{
    public class AdministratorBankariController : Controller
    {
        private BankariProxy _bankari;
        private IAdministratori _administratori;
        private Korisnik korisnik;
        public AdministratorBankariController(OOADContext context)
        {
            _bankari = new BankariProxy(context);
        }

        // GET: AdministratorBankari
        public async Task<IActionResult> Index()
        {
            return View(await _bankari.DajSveBankare());
        }

        // GET: AdministratorBankari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministratorBankari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Prezime,KorisnickoIme,Lozinka,MjestoZaposlenja")] Bankar bankar)
        {
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
            await _bankari.UkloniBankara(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BankarExists(int id)
        {
            return _bankari.DaLiPostojiBankar(id);
        }
    }
}
