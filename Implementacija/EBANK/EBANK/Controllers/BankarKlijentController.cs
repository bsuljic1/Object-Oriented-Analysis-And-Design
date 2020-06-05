using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.KlijentRepository;
using EBANK.Models.BankarRepository;
using EBANK.Utils;
using EBANK.Models.TransakcijaRepository;

namespace EBANK.Controllers
{
    public class BankarKlijentController : Controller
    {
        private KlijentiProxy _klijenti;
        private OOADContext Context;
        private TransakcijeProxy _transakcije;
        private Korisnik korisnik;

        public BankarKlijentController(OOADContext context)
        {
            _klijenti = new KlijentiProxy(context);
            Context = context;
            _transakcije = new TransakcijeProxy(context);
        }

        // GET: BankarKlijent
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);
            ViewData["Ime"] = korisnik.Ime;
            return View(await _klijenti.DajSveKlijente());
        }

        // GET: BankarKlijent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _klijenti.DajKlijenta(id);
            if (klijent == null)
            {
                return NotFound();
            }

            var transakcije = await _transakcije.DajTransakcije(id);

            return View(klijent);
        }

        // GET: BankarKlijent/Create
        public async Task<IActionResult> CreateAsync()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            return View();
        }

        // POST: BankarKlijent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatumRodjenja,JMBG,BrojTelefona,BrojLicneKarte,Zanimanje,Ime,Prezime,KorisnickoIme,Lozinka,Adresa")] Klijent klijent)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

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
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

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
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

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
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

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
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            await _klijenti.UkloniKlijenta(id);
            return RedirectToAction(nameof(Index));
        }

        private bool KlijentExists(int id)
        {
            return _klijenti.DaLiPostojiKlijent(id);
        }
    }
}
