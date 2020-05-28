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
    public class BankarKreditController : Controller
    {
        private readonly OOADContext _context;

        public BankarKreditController(OOADContext context)
        {
            _context = context;
        }

        // GET: Kredit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kredit.ToListAsync());
        }

        // GET: Kredit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kredit = await _context.Kredit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kredit == null)
            {
                return NotFound();
            }

            return View(kredit);
        }

        // GET: Kredit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kredit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsplaceniIznos,PocetakOtplate,StatusKredita,Iznos,KamatnaStopa,RokOtplate")] Kredit kredit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kredit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kredit);
        }

        // GET: Kredit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kredit = await _context.Kredit.FindAsync(id);
            if (kredit == null)
            {
                return NotFound();
            }
            return View(kredit);
        }

        // POST: Kredit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IsplaceniIznos,PocetakOtplate,StatusKredita,Iznos,KamatnaStopa,RokOtplate")] Kredit kredit)
        {
            if (id != kredit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kredit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KreditExists(kredit.Id))
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
            return View(kredit);
        }

        // GET: Kredit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kredit = await _context.Kredit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kredit == null)
            {
                return NotFound();
            }

            return View(kredit);
        }

        // POST: Kredit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kredit = await _context.Kredit.FindAsync(id);
            _context.Kredit.Remove(kredit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KreditExists(int id)
        {
            return _context.Kredit.Any(e => e.Id == id);
        }
    }
}
