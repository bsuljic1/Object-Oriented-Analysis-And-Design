using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.KreditRepository
{
    public class Krediti : IKrediti, IZahtjevObserver
    {
        private OOADContext _context;

        public Krediti(OOADContext context)
        {
            _context = context;
        }
       
        public async Task<Kredit> DajKredit(int? id)
        {
            Kredit kredit = await _context.Kredit.FindAsync(id);
            return kredit;
        }

        public async Task<List<Kredit>> DajSveKredite()
        {
            return await _context.Kredit.Include("Racun").Include("Racun.Klijent").ToListAsync();
        }

        public bool DaLiPostojiKredit(int? id)
        {
            return _context.Kredit.Any(e => e.Id == id);
        }

        public async Task NaOdobrenZahtjev(Kredit kredit)
        {
            _context.Add(kredit);
            await _context.SaveChangesAsync();
        }
    }
}
