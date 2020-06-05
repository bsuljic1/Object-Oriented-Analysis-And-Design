using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.KlijentRepository;
using EBANK.Models.AdministratorRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class AdministratorKlijentiController : Controller
    {
        private Korisnik korisnik;
        KlijentiProxy _klijenti;
        private OOADContext Context;

        public AdministratorKlijentiController(OOADContext context)
        {
            Context = context;
            _klijenti = new KlijentiProxy(context);
        }

        // GET: AdministratorKlijenti
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            return View(await _klijenti.DajSveKlijente());
        }

        // GET: AdministratorKlijenti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);
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

        // GET: AdministratorKlijenti/Create
        
        private bool KlijentExists(int id)
        {
            return _klijenti.DaLiPostojiKlijent(id);
        }
    }
}
