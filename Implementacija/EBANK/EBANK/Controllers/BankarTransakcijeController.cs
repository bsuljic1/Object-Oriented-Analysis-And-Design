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
    public class BankarTransakcijeController : Controller
    {
        readonly ITransakcije _transakcije;

        public BankarTransakcijeController(OOADContext context)
        {
            _transakcije = new TransakcijeProxy(context);
        }

        // GET: BankarTransakcije
        public async Task<IActionResult> Index()
        {
            return View(await _transakcije.DajSveTransakcije());
        }

        // GET: BankarTransakcije/Details/5
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

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
