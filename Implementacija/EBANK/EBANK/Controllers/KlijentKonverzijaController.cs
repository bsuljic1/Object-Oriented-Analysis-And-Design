using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBANK.Data;
using EBANK.Models;
using System.Net.Http;
using Newtonsoft.Json;
using EBANK.Utils;

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
        public async Task<IActionResult> Index([Bind("Iznos,IzValute,UValutu")] Konverzija konverzija = null)
        {
            if (konverzija != null)
                konverzija.KonvertovaniIznos = await new Konvertor().konvertujDevizuAsync(konverzija.Iznos, ImeValute(konverzija.IzValute), ImeValute(konverzija.UValutu));
                    
            return View(konverzija);
        }

        public string ImeValute(Valuta valuta)
        {
            switch (valuta)
            {
                case Valuta.BAM:
                    return "BAM";
                case Valuta.EUR:
                    return "EUR";
                case Valuta.RSD:
                    return "RSD";
                case Valuta.USD:
                    return "USD";
                default:
                    return "HRK";
            }
        }
    }
}
