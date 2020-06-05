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
using EBANK.Models.BankarRepository;
using EBANK.Utils;

namespace EBANK.Controllers
{
    public class BankarHomeController : Controller
    {
        private IBankari _bankari;
        private Korisnik korisnik;
        private OOADContext Context;

        public BankarHomeController(OOADContext context)
        {
            Context = context;
            _bankari = new BankariProxy(context);
        }

        public async Task<IActionResult> Index()
        {
            korisnik = await LoginUtils.Authenticate(Request, Context, this);
            if (korisnik == null) return RedirectToAction("Logout", "Login", new { area = "" });

            return View(korisnik);
        }
    }
}
