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
    public class KonverzijaController : Controller
    {
        private readonly OOADContext _context;

        public KonverzijaController(OOADContext context)
        {
            _context = context;
        }

        // GET: Konverzija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Konverzija.ToListAsync());
        }

        // GET: Konverzija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konverzija = await _context.Konverzija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konverzija == null)
            {
                return NotFound();
            }

            return View(konverzija);
        }

        // GET: Konverzija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konverzija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iznos,IzValute,UValutu")] Konverzija konverzija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konverzija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konverzija);
        }

        // GET: Konverzija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konverzija = await _context.Konverzija.FindAsync(id);
            if (konverzija == null)
            {
                return NotFound();
            }
            return View(konverzija);
        }

        // POST: Konverzija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Iznos,IzValute,UValutu")] Konverzija konverzija)
        {
            if (id != konverzija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konverzija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonverzijaExists(konverzija.Id))
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
            return View(konverzija);
        }

        // GET: Konverzija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konverzija = await _context.Konverzija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konverzija == null)
            {
                return NotFound();
            }

            return View(konverzija);
        }

        // POST: Konverzija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konverzija = await _context.Konverzija.FindAsync(id);
            _context.Konverzija.Remove(konverzija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonverzijaExists(int id)
        {
            return _context.Konverzija.Any(e => e.Id == id);
        }
    }
}
