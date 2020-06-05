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
using EBANK.Models.KlijentRepository;

namespace EBANK.Controllers
{
    public class BankarRacunController : Controller
    {
        private IRacuni _racuni;
        private IKlijenti _klijenti;

        public BankarRacunController(OOADContext context)
        {
            _racuni = new RacuniProxy(context);
            _klijenti = new KlijentiProxy(context);
        }

        // GET: BankarRacun
        public async Task<IActionResult> Index()
        {
            return View(await _racuni.DajSveRacune());
        }

        

        // GET: BankarRacun/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankarRacun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StanjeRacuna,VrstaRacuna,Klijent")] Racun racun)
        {
            Klijent klijent = await _klijenti.DajKlijentaLK(racun.Klijent.BrojLicneKarte);
            if (klijent != null)
            {
                racun.Klijent = klijent;
                await _racuni.OtvoriRacun(racun);
                return RedirectToAction(nameof(Index));
            }
            return View(racun);
        }

 
        // GET: BankarRacun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racun = await _racuni.DajRacun(id);
            if (racun == null)
            {
                return NotFound();
            }

            return View(racun);
        }

        // POST: BankarRacun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _racuni.ZatvoriRacun(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RacunExists(int id)
        {
            return _racuni.DaLiPostojiRacun(id);
        }
    }
}
