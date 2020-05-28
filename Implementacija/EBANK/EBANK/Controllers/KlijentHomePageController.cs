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
    public class KlijentHomePageController : Controller
    {
        private readonly OOADContext _context;

        public KlijentHomePageController(OOADContext context)
        {
            _context = context;
        }

        // GET: KlijentHomePage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Novost.ToListAsync());
        }

        private bool NovostExists(int id)
        {
            return _context.Novost.Any(e => e.Id == id);
        }
    }
}
