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

namespace EBANK.Controllers
{
    public class AdministratorKlijentiController : Controller
    {
        IKlijenti _klijenti;
        public AdministratorKlijentiController(OOADContext context)
        {
            _klijenti = new KlijentiProxy(context);
        }

        // GET: AdministratorKlijenti
        public async Task<IActionResult> Index()
        {
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
