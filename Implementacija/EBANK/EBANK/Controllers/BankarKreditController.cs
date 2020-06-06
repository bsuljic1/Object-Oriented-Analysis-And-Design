using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.KreditRepository;
using EBANK.Models.BankarRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class BankarKreditController : Controller
    {
        private KreditiProxy _krediti;
        private OOADContext Context;
        private Korisnik korisnik;

        public BankarKreditController(OOADContext context)
        {
            _krediti = new KreditiProxy(context);
            Context = context;
        }

        // GET: Kredit
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _krediti.Pristupi(korisnik);

            ViewData["Ime"] = korisnik.Ime;
            var krediti = await _krediti.DajSveKredite();
          
            return View(krediti);
        }

    }
}
