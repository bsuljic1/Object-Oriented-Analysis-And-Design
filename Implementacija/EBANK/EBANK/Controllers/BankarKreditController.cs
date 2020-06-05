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

namespace EBANK.Controllers
{
    public class BankarKreditController : Controller
    {
        private KreditiProxy _krediti;
        private IBankari _bankari;
        private Korisnik korisnik;

        public BankarKreditController(OOADContext context)
        {
            _krediti = new KreditiProxy(context);
            _bankari = new BankariProxy(context);
        }

        // GET: Kredit
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Bankar")
                korisnik = await _bankari.DajBankara(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _krediti.Pristupi(korisnik);
            return View(await _krediti.DajSveKredite());
        }

    }
}
