using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.RacunRepository
{
    public class Racuni : IRacuni
    {
        private OOADContext _context;

        public Racuni(OOADContext context)
        {
            _context = context;
        }

        public async Task<Racun> DajRacun(int? id)
        {
            Racun racun = await _context.Racun.Where(m => m.Id == id).FirstAsync();
            return racun;
        }

        public async Task<List<Racun>> DajSveRacune()
        {
            return await _context.Racun.ToListAsync();
        }

        public bool DaLiPostojiRacun(int? id)
        {
            return _context.Racun.Any(e => e.Id == id);
        }

        public async Task OtvoriRacun(Racun racun)
        {
            _context.Add(racun);
            await _context.SaveChangesAsync();
        }

        public async Task ZatvoriRacun(int? id)
        {
            var racun = await _context.Racun.FindAsync(id);
            _context.Racun.Remove(racun);
            await _context.SaveChangesAsync();
        }

    
        public async Task<List<Racun>> DajSveRacuneKlijenta(int? id)
        {
            return await _context.Racun.Where(m => m.Klijent.Id == id).ToListAsync();
        }
    }
}

