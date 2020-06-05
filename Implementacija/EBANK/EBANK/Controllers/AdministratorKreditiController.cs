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
using EBANK.Models.AdministratorRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class AdministratorKreditiController : Controller
    {
        private OOADContext Context;
        private Korisnik korisnik;
        private KreditiProxy _krediti;

        public AdministratorKreditiController(OOADContext context)
        {
            Context = context;
            _krediti = new KreditiProxy(context);
        }

        // GET: Kredit
        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            _krediti.Pristupi(korisnik);

            @ViewData["Ime"] = korisnik.Ime;

            return View(await _krediti.DajSveKredite());
        }
    }
}
