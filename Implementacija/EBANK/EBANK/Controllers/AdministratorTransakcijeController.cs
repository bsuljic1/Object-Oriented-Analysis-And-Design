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
using EBANK.Models.AdministratorRepository;

namespace EBANK.Controllers
{
    public class AdministratorTransakcijeController : Controller
    {
        private readonly TransakcijeProxy _transakcije;
        private IAdministratori _administratori;
        private Korisnik korisnik;

        public AdministratorTransakcijeController(OOADContext context)
        {
            _administratori = new AdministratoriProxy(context);
            _transakcije = new TransakcijeProxy(context);
        }

        // GET: AdministratorTransakcije
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Administrator")
                korisnik = await _administratori.DajAdministratora(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _transakcije.Pristupi(korisnik);
            return View(await _transakcije.DajSveTransakcije());
        }

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
