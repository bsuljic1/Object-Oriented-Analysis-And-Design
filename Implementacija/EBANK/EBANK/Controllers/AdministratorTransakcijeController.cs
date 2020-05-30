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
    public class AdministratorTransakcijeController : Controller
    {
        private readonly ITransakcije _transakcije;

        public AdministratorTransakcijeController(OOADContext context)
        {
            _transakcije = new TransakcijeProxy(context);
        }

        // GET: AdministratorTransakcije
        public async Task<IActionResult> Index()
        {
            return View(await _transakcije.DajSveTransakcije());
        }

        private bool TransakcijaExists(int id)
        {
            return _transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
