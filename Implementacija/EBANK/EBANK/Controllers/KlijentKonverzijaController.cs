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
            if(konverzija != null)
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://data.fixer.io/api/latest" +
                        "?access_key=ba8e84f219054816408d7814d5b43b0c");

                    var result = await client.GetAsync("");
                    if (result.IsSuccessStatusCode)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        var rates = JsonConvert.DeserializeXNode(response, "a").Root.Element("rates");
                        var from = float.Parse(rates.Element(ImeValute(konverzija.IzValute)).Value);
                        var to = float.Parse(rates.Element(ImeValute(konverzija.UValutu)).Value);
                        konverzija.KonvertovaniIznos = konverzija.Iznos * to / from;
                    }
                }

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
