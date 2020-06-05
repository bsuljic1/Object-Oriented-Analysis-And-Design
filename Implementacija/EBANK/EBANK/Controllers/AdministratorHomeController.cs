using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EBANK.Models;
using EBANK.Models.AdministratorRepository;
using EBANK.Data;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class AdministratorHomeController : Controller
    {
        private IAdministratori _administratori;
        private Korisnik korisnik;
        private OOADContext Context;

        public AdministratorHomeController(OOADContext context)
        {
            _administratori = new AdministratoriProxy(context);
            Context = context;
        }

        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });
         
            ViewData["Ime"] = korisnik.Ime;
            return View(korisnik);
        }
    }
}
