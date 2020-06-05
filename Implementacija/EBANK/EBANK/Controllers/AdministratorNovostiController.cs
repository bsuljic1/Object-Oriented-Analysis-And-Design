using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.NovostRepository;
using EBANK.Models.AdministratorRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class AdministratorNovostiController : Controller
    {

        private OOADContext Context;
        private Korisnik korisnik;
        private OglasnaPlocaProxy _novosti;

        public AdministratorNovostiController(OOADContext context)
        {
            Context = context;
            _novosti = new OglasnaPlocaProxy(context);
            //_klijenti.Pristupi();korisnik = await LoginUtils.Authenticate(Request, Context, this);
        }

        // GET: AdministratorNovosti
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _novosti.Pristupi(korisnik);

            return View(await _novosti.DajSveNovosti());
        }

        // GET: AdministratorNovosti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novost = await _novosti.DajNovost(id);
            if (novost == null)
            {
                return NotFound();
            }

            return View(novost);
        }

        // GET: AdministratorNovosti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministratorNovosti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vrijemeDodavanja,Naslov,Sadrzaj,Prikazana")] Novost novost)
        {
            if (ModelState.IsValid)
            {
                await _novosti.DodajNovost(novost);
                return RedirectToAction(nameof(Index));
            }
            return View(novost);
        }
    

    // GET: AdministratorNovosti/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var novost = await _novosti.DajNovost(id);
        if (novost == null)
        {
            return NotFound();
        }
        return View(novost);
    }

    // POST: AdministratorNovosti/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,vrijemeDodavanja,Naslov,Sadrzaj,Prikazana")] Novost novost)
        {
            if (id != novost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _novosti.UrediNovost(novost);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovostExists(novost.Id))
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
            return View(novost);
        }

        // GET: AdministratorNovosti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novost = await _novosti.DajNovost(id);
            if (novost == null)
            {
                return NotFound();
            }

            return View(novost);
        }

        // POST: AdministratorNovosti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _novosti.UkloniNovost(id);
            return RedirectToAction(nameof(Index));
        }

        private bool NovostExists(int id)
        {
            return _novosti.DaLiPostojiNovost(id);
        }
    }
}
