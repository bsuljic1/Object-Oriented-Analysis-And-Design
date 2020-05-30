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

namespace EBANK.Controllers
{
    public class AdministratorRacuniController : Controller
    {
        private readonly IRacuni _racuni;

        public AdministratorRacuniController(OOADContext context)
        {
            _racuni = new RacuniProxy(context);
        }

        // GET: AdministratorRacuni
        public async Task<IActionResult> Index()
        {
            return View(await _racuni.DajSveRacune());
        }

     
        private bool RacunExists(int id)
        {
            return _racuni.DaLiPostojiRacun(id);
        }
    }
}
