using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;

namespace EBANK.Controllers
{
    public class KlijentKonverzijaController : Controller
    {
        private readonly OOADContext _context;

        public KlijentKonverzijaController(OOADContext context)
        {
            _context = context;
        }

        // GET: Konverzija
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
