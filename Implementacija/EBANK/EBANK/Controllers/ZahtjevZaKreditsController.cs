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
    public class ZahtjevZaKreditsController : Controller
    {
        private readonly OOADContext _context;

        public ZahtjevZaKreditsController(OOADContext context)
        {
            _context = context;
        }

        // GET: ZahtjevZaKredits
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZahtjevZaKredit.ToListAsync());
        }

        // GET: ZahtjevZaKredits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaKredit = await _context.ZahtjevZaKredit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahtjevZaKredit == null)
            {
                return NotFound();
            }

            return View(zahtjevZaKredit);
        }

        // GET: ZahtjevZaKredits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZahtjevZaKredits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamjenaKredita,MjesecniPrihodi,ProsjecniTroskoviDomacinstva,NazivRadnogMjesta,NazivPoslodavca,RadniStaz,BrojNekretnina,BracnoStanje,SupruznikIme,SupruznikPrezime,SupruznikZanimanje,ImaNeplacenihDugova,BrojNeplacenihDugova,StatusZahtjeva,Iznos,KamatnaStopa,RokOtplate")] ZahtjevZaKredit zahtjevZaKredit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahtjevZaKredit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahtjevZaKredit);
        }

        // GET: ZahtjevZaKredits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaKredit = await _context.ZahtjevZaKredit.FindAsync(id);
            if (zahtjevZaKredit == null)
            {
                return NotFound();
            }
            return View(zahtjevZaKredit);
        }

        // POST: ZahtjevZaKredits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NamjenaKredita,MjesecniPrihodi,ProsjecniTroskoviDomacinstva,NazivRadnogMjesta,NazivPoslodavca,RadniStaz,BrojNekretnina,BracnoStanje,SupruznikIme,SupruznikPrezime,SupruznikZanimanje,ImaNeplacenihDugova,BrojNeplacenihDugova,StatusZahtjeva,Iznos,KamatnaStopa,RokOtplate")] ZahtjevZaKredit zahtjevZaKredit)
        {
            if (id != zahtjevZaKredit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjevZaKredit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevZaKreditExists(zahtjevZaKredit.Id))
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
            return View(zahtjevZaKredit);
        }

        // GET: ZahtjevZaKredits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjevZaKredit = await _context.ZahtjevZaKredit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahtjevZaKredit == null)
            {
                return NotFound();
            }

            return View(zahtjevZaKredit);
        }

        // POST: ZahtjevZaKredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahtjevZaKredit = await _context.ZahtjevZaKredit.FindAsync(id);
            _context.ZahtjevZaKredit.Remove(zahtjevZaKredit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevZaKreditExists(int id)
        {
            return _context.ZahtjevZaKredit.Any(e => e.Id == id);
        }
    }
}
