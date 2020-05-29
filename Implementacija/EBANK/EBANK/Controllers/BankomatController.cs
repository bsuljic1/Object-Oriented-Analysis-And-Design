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

namespace EBANK.Controllers
{
    public class BankomatController : Controller
    {
        private IFilijaleBankomati _filijaleBankomati;

        public BankomatController(OOADContext context)
        {
            _filijaleBankomati = new FilijaleBankomatiProxy(context);
        }

        // GET: Bankomat
        public async Task<IActionResult> Index()
        {
            return View(await _filijaleBankomati.DajSveBankomate());
        }

        // GET: Bankomat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bankomat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Adresa")] Bankomat bankomat)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("Ime")] Bankomat bankomat)
        {
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
            await _filijaleBankomati.UkloniBankomat(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BankomatExists(int id)
        {
            return _filijaleBankomati.DaLiPostojiBankomat(id);
        }
    }
}
