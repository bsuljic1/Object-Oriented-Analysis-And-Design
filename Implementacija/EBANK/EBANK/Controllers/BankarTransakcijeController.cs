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

namespace EBANK.Controllers
{
    public class BankarTransakcijeController : Controller
    {
        readonly TransakcijeProxy _transakcije;
        private IBankari _bankari;
        private Korisnik korisnik;

        public BankarTransakcijeController(OOADContext context)
        {
            _transakcije = new TransakcijeProxy(context);
            _bankari = new BankariProxy(context);
        }

        // GET: BankarTransakcije
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Bankar")
                korisnik = await _bankari.DajBankara(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);
            return View(await _transakcije.DajSveTransakcije());
        }

        // GET: BankarTransakcije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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
