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

namespace EBANK.Controllers
{
    public class AdministratorFilijaleController : Controller
    {
        FilijaleBankomatiProxy _filijaleBankomati;
        private IAdministratori _administratori;
        private Korisnik korisnik;

        public AdministratorFilijaleController(OOADContext context)
        {
            _filijaleBankomati = new FilijaleBankomatiProxy(context);
            _administratori = new AdministratoriProxy(context);
        }

        // GET: Filijala
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Administrator")
                korisnik = await _administratori.DajAdministratora(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _filijaleBankomati.Pristupi(korisnik);

            return View(await _filijaleBankomati.DajSveFilijale());
        }

        // GET: Filijala/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filijala = await _filijaleBankomati.DajFilijalu(id);
            if (filijala == null)
            {
                return NotFound();
            }

            return View(filijala);
        }

        // GET: Filijala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filijala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,BrojTelefona,Adresa")] Filijala filijala)
        {
            if (ModelState.IsValid)
            {
                await _filijaleBankomati.DodajFilijalu(filijala);
                return RedirectToAction(nameof(Index));
            }
            return View(filijala);
        }

        // GET: Filijala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filijala = await _filijaleBankomati.DajFilijalu(id);
            if (filijala == null)
            {
                return NotFound();
            }
            return View(filijala);
        }

        // POST: Filijala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,BrojTelefona,Adresa")] Filijala filijala)
        {
            if (id != filijala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _filijaleBankomati.UrediFilijalu(filijala);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilijalaExists(filijala.Id))
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
            return View(filijala);
        }

        // GET: Filijala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filijala = await _filijaleBankomati.DajFilijalu(id);
            if (filijala == null)
            {
                return NotFound();
            }

            return View(filijala);
        }

        // POST: Filijala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _filijaleBankomati.UkloniFilijalu(id) ;
            return RedirectToAction(nameof(Index));
        }

        private bool FilijalaExists(int id)
        {
            return _filijaleBankomati.DaLiPostojiFilijala(id);
        }
    }
}
