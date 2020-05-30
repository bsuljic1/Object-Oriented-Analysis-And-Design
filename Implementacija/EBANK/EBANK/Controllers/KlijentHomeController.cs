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
using EBANK.Models.KlijentRepository;

namespace EBANK.Controllers
{
    public class KlijentHomeController : Controller
    {
        private IKlijenti _klijenti;
        private Klijent klijent;

        public KlijentHomeController(OOADContext context)
        {
            _klijenti = new KlijentiProxy(context);
        }

        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Klijent")
                klijent = await _klijenti.DajKlijenta(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            return View(klijent);
        }
    }
}
