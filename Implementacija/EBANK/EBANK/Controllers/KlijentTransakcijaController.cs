using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;

namespace EBANK.Controllers
{
    public class KlijentTransakcijaController : Controller
    {
        private readonly OOADContext _context;

        public KlijentTransakcijaController(OOADContext context)
        {
            _context = context;
        }

        // GET: KlijentTransakcija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transakcija.ToListAsync());
        }

        // GET: KlijentTransakcija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _context.Transakcija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return View(transakcija);
        }

        // GET: KlijentTransakcija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KlijentTransakcija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vrijeme,Iznos,VrstaTransakcije,NacinTransakcije")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transakcija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transakcija);
        }

        // GET: KlijentTransakcija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _context.Transakcija.FindAsync(id);
            if (transakcija == null)
            {
                return NotFound();
            }
            return View(transakcija);
        }

        // POST: KlijentTransakcija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Vrijeme,Iznos,VrstaTransakcije,NacinTransakcije")] Transakcija transakcija)
        {
            if (id != transakcija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transakcija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransakcijaExists(transakcija.Id))
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
            return View(transakcija);
        }

        // GET: KlijentTransakcija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _context.Transakcija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return View(transakcija);
        }

        // POST: KlijentTransakcija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transakcija = await _context.Transakcija.FindAsync(id);
            _context.Transakcija.Remove(transakcija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransakcijaExists(int id)
        {
            return _context.Transakcija.Any(e => e.Id == id);
        }
    }
}
