using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.KlijentRepository;
using EBANK.Models.AdministratorRepository;

namespace EBANK.Controllers
{
    public class AdministratorKlijentiController : Controller
    {
        private IAdministratori _administratori;
        private Korisnik korisnik;
        KlijentiProxy _klijenti;

        public AdministratorKlijentiController(OOADContext context)
        {
         
            _administratori = new AdministratoriProxy(context);
            _klijenti = new KlijentiProxy(context);
        }

        // GET: AdministratorKlijenti
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Administrator")
                korisnik = await _administratori.DajAdministratora(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _klijenti.Pristupi(korisnik);

            return View(await _klijenti.DajSveKlijente());
        }

        // GET: AdministratorKlijenti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _klijenti.DajKlijenta(id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // GET: AdministratorKlijenti/Create
        
        private bool KlijentExists(int id)
        {
            return _klijenti.DaLiPostojiKlijent(id);
        }
    }
}
