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
    public class AdministratorBankariController : Controller
    {
        private readonly OOADContext _context;

        public AdministratorBankariController(OOADContext context)
        {
            _context = context;
        }

        // GET: AdministratorBankari
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bankar.ToListAsync());
        }

        // GET: AdministratorBankari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankar = await _context.Bankar
                .FirstOrDefaultAsync(m => m.Id == id);
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
                _context.Add(bankar);
                await _context.SaveChangesAsync();
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

            var bankar = await _context.Bankar.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Ime,Prezime,KorisnickoIme,Lozinka")] Bankar bankar)
        {
            if (id != bankar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankar);
                    await _context.SaveChangesAsync();
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

            var bankar = await _context.Bankar
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var bankar = await _context.Bankar.FindAsync(id);
            _context.Bankar.Remove(bankar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankarExists(int id)
        {
            return _context.Bankar.Any(e => e.Id == id);
        }
    }
}
