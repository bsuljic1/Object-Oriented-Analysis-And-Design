using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.ZahtjevZaKreditRepository;
using EBANK.Models.KreditRepository;
using EBANK.Models.BankarRepository;

namespace EBANK.Controllers
{
    public class BankarZahtjevZaKreditController : Controller
    {
        private ZahtjeviZaKreditProxy _zahtjevi;
        private IBankari _bankari;
        private Korisnik korisnik;

        public BankarZahtjevZaKreditController(OOADContext context)
        {
            _zahtjevi = new ZahtjeviZaKreditProxy(context);
            _bankari = new BankariProxy(context);
        }

        // GET: BankarZahtjevZaKredit
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Bankar")
                korisnik = await _bankari.DajBankara(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _zahtjevi.Pristupi(korisnik);
            return View(await _zahtjevi.DajSveZahtjeve());
        }

        // GET: BankarZahtjevZaKredit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var zahtjev = await _zahtjevi.DajZahtjev(id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

        
        // POST: BakarZahtjevZaKredit/Odobri/5
        public async Task<IActionResult> Odobri(int id)
        {
            ZahtjevZaKredit zahtjevZaKredit = await _zahtjevi.DajZahtjev(id);
            await _zahtjevi.RijesiZahtjev(id, true);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Odbij(int id)
        {
            await _zahtjevi.RijesiZahtjev(id, false);
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevZaKreditExists(int id)
        {
            return _zahtjevi.DaLiPostojiZahtjev(id);
        }
    }
}
