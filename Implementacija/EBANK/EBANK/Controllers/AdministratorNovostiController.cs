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
    public class AdministratorNovostiController : Controller
    {
        private readonly OOADContext _context;

        public AdministratorNovostiController(OOADContext context)
        {
            _context = context;
        }

        // GET: AdministratorNovosti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Novost.ToListAsync());
        }

        // GET: AdministratorNovosti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novost = await _context.Novost
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,vrijemeDodavanja,Naslov,Sadrzaj,Prikazana")] Novost novost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novost);
                await _context.SaveChangesAsync();
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

            var novost = await _context.Novost.FindAsync(id);
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
                    _context.Update(novost);
                    await _context.SaveChangesAsync();
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

            var novost = await _context.Novost
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var novost = await _context.Novost.FindAsync(id);
            _context.Novost.Remove(novost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovostExists(int id)
        {
            return _context.Novost.Any(e => e.Id == id);
        }
    }
}
