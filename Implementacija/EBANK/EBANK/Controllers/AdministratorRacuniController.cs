using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using EBANK.Models.RacunRepository;
using EBANK.Models.AdministratorRepository;

namespace EBANK.Controllers
{
    public class AdministratorRacuniController : Controller
    {
        private readonly RacuniProxy _racuni;
        private IAdministratori _administratori;
        private Korisnik korisnik;

        public AdministratorRacuniController(OOADContext context)
        {
            _administratori = new AdministratoriProxy(context);
            _racuni = new RacuniProxy(context);
        }

        // GET: AdministratorRacuni
        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Administrator")
                korisnik = await _administratori.DajAdministratora(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            _racuni.Pristupi(korisnik);
            return View(await _racuni.DajSveRacune());
        }

     
        private bool RacunExists(int id)
        {
            return _racuni.DaLiPostojiRacun(id);
        }
    }
}
