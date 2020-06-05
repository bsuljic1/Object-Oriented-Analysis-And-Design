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

namespace EBANK.Controllers
{
    public class AdministratorKreditiController : Controller
    {
        private IAdministratori _administratori;
        private Korisnik korisnik;
        private KreditiProxy _krediti;

        public AdministratorKreditiController(OOADContext context)
        {
            _administratori = new AdministratoriProxy(context);
            _krediti = new KreditiProxy(context);
        }

        // GET: Kredit
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Administrator")
                korisnik = await _administratori.DajAdministratora(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _krediti.Pristupi(korisnik);

            return View(await _krediti.DajSveKredite());
        }
    }
}
