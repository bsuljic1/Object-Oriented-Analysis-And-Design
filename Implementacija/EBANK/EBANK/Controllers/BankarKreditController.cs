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

namespace EBANK.Controllers
{
    public class BankarKreditController : Controller
    {
        private IKrediti _krediti;

        public BankarKreditController(OOADContext context)
        {
            _krediti = new KreditiProxy(context);
        }

        // GET: Kredit
        public async Task<IActionResult> Index()
        {
            return View(await _krediti.DajSveKredite());
        }

    }
}
