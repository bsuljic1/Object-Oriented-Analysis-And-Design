using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.KreditRepository
{
    public class Krediti : IKrediti
    {
        private OOADContext _context;

        public Krediti(OOADContext context)
        {
            _context = context;
        }
        public async Task PokreniKredit(ZahtjevZaKredit zahtjevZaKredit)
        {
            _context.Add(zahtjevZaKredit);
            await _context.SaveChangesAsync();
        }
        public async Task<Kredit> DajKredit(int? id)
        {
            Kredit kredit = await _context.Kredit.FindAsync(id);
            return kredit;
        }

        public async Task<List<Kredit>> DajSveKredite()
        {
            return await _context.Kredit.ToListAsync();
        }

        public bool DaLiPostojiKredit(int? id)
        {
            return _context.Kredit.Any(e => e.Id == id);
        }
    }
}
