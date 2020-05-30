using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.AdministratorRepository;
using EBANK.Models.BankarRepository;
using EBANK.Models.KlijentRepository;
using Microsoft.AspNetCore.Mvc;

namespace EBANK.Controllers
{
    public class LoginController : Controller
    {
        private IAdministratori _administratori;
        private IBankari _bankari;
        private IKlijenti _klijenti;
        public LoginController(OOADContext context)
        {
            _administratori = new AdministratoriProxy(context);
            _bankari = new BankariProxy(context);
            _klijenti = new KlijentiProxy(context);
        }

        public IActionResult Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role != null && userId.Length > 0 && role.Length > 0)
                return RedirectToAction("Index", "Home", new { area = "" });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("KorisnickoIme,Lozinka")] Korisnik korisnik)
        {
            var administrator = await _administratori.DajAdministratora(korisnik.KorisnickoIme);

            if (administrator != null)
            {
                Response.Cookies.Append("userId", administrator.Id.ToString());
                Response.Cookies.Append("role", "Administrator");
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var bankar = await _bankari.DajBankara(korisnik.KorisnickoIme);

            if (bankar != null)
            {
                Response.Cookies.Append("userId", bankar.Id.ToString());
                Response.Cookies.Append("role", "Bankar");
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var klijent = await _klijenti.DajKlijenta(korisnik.KorisnickoIme);

            if (klijent != null)
            {
                Response.Cookies.Append("userId", klijent.Id.ToString());
                Response.Cookies.Append("role", "Klijent");
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return RedirectToAction("Index");
        }
    }
}
