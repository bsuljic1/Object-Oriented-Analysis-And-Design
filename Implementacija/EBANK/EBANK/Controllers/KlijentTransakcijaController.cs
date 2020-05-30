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

namespace EBANK.Controllers
{
    public class KlijentTransakcijaController : Controller
    {
         private ITransakcije _transakcije;

        public KlijentTransakcijaController(OOADContext context)
        {
            _transakcije = new TransakcijeProxy(context);
            //_klijenti.Pristupi();
        }

        // GET: KlijentTransakcija
        public async Task<IActionResult> Index()
        {
            return View(await _transakcije.DajSveTransakcije());
        }

        // GET: KlijentTransakcija/Details/5
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

        // GET: KlijentTransakcija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KlijentTransakcija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vrijeme,Iznos,VrstaTransakcije,NacinTransakcije")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                await _transakcije.Uplati(transakcija);
                return RedirectToAction(nameof(Index));
            }
            return View(transakcija);
        }

        
       

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
