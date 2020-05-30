using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    public class Transakcije : ITransakcije
    {
        private readonly OOADContext _context;

        public Transakcije(OOADContext context)
        {
            _context = context;
        }

        public async Task<List<Transakcija>> DajSveTransakcije()
        {
            return await _context.Transakcija.Include("NaRacun").Include("SaRacuna").ToListAsync();
        }

        public async Task<Transakcija> DajTransakciju(int? id)
        {
            Transakcija transakcija = await _context.Transakcija.Include("NaRacun").Include("SaRacuna").Where(m => m.Id == id).FirstAsync();
            return transakcija;
        }

        public bool DaLiPostojiTransakcija(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Uplati(Racun saRacuna, Racun naRacun, float iznos)
        {
            throw new NotImplementedException();
        }
    }
}
