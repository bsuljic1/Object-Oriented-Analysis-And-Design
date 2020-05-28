﻿using System;
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
    public class KlijentIzvrsiUplatuController : Controller
    {
        private readonly OOADContext _context;

        public KlijentIzvrsiUplatuController(OOADContext context)
        {
            _context = context;
        }


        // GET: KlijentIzvrsiUplatu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KlijentIzvrsiUplatu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vrijeme,Iznos,VrstaTransakcije,NacinTransakcije")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transakcija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transakcija);
        }

      
        private bool TransakcijaExists(int id)
        {
            return _context.Transakcija.Any(e => e.Id == id);
        }
    }
}
