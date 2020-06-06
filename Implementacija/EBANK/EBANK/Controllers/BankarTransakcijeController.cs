using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.TransakcijaRepository;
using EBANK.Models.BankarRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class BankarTransakcijeController : Controller
    {
        readonly TransakcijeProxy _transakcije;
        private OOADContext Context;
        private Korisnik korisnik;

        public BankarTransakcijeController(OOADContext context)
        {
            _transakcije = new TransakcijeProxy(context);
            Context = context;
        }

        // GET: BankarTransakcije
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            return View(await _transakcije.DajSveTransakcije());
        }

        // GET: BankarTransakcije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;

            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _transakcije.DajTransakciju(id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return View(transakcija);
        }

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
