using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.KlijentRepository;

namespace EBANK.Controllers
{
    public class BankarKlijentController : Controller
    {
        private IKlijenti _klijenti;

        public BankarKlijentController(OOADContext context)
        {
            _klijenti = new KlijentiProxy(context);
            //_klijenti.Pristupi();
        }

        // GET: BankarKlijent
        public async Task<IActionResult> Index()
        {
            return View(await _klijenti.DajSveKlijente());
        }

        // GET: BankarKlijent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _klijenti.DajKlijenta(id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // GET: BankarKlijent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankarKlijent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatumRodjenja,JMBG,BrojTelefona,BrojLicneKarte,Zanimanje,Ime,Prezime,KorisnickoIme,Lozinka,Adresa")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                await _klijenti.DodajKlijenta(klijent);
                return RedirectToAction(nameof(Index));
            }
            return View(klijent);
        }

        // GET: BankarKlijent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _klijenti.DajKlijenta(id);
            if (klijent == null)
            {
                return NotFound();
            }
            return View(klijent);
        }

        // POST: BankarKlijent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatumRodjenja,JMBG,BrojTelefona,BrojLicneKarte,Zanimanje,Ime,Prezime,KorisnickoIme,Lozinka,Adresa")] Klijent klijent)
        {
            if (id != klijent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _klijenti.UrediKlijenta(klijent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlijentExists(klijent.Id))
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
            return View(klijent);
        }

        // GET: BankarKlijent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _klijenti.DajKlijenta(id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // POST: BankarKlijent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _klijenti.UkloniKlijenta(id);
            return RedirectToAction(nameof(Index));
        }

        private bool KlijentExists(int id)
        {
            return _klijenti.DaLiPostojiKlijent(id);
        }
    }
}
