using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    public class FilijaleBankomati : IFilijaleBankomati 
    {
        private OOADContext _context;

        public FilijaleBankomati(OOADContext context)
        {
            this._context = context;
        }

        async Task<IMapObjekat> IFilijaleBankomati.DajMapObjekat(int? id)
        {
            throw new NotImplementedException();
        }

        Task<List<IMapObjekat>> IFilijaleBankomati.DajSveMapObjekte()
        {
            throw new NotImplementedException();
        }

        public bool DaLiPostojiMapObjekat(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task DodajBankomat(Bankomat bankomat)
        {
            _context.Add(bankomat);
            await _context.SaveChangesAsync();
        }

        public async Task DodajFilijalu(Filijala filijala)
        {
            _context.Add(filijala);
            await _context.SaveChangesAsync();
        }

        Task IFilijaleBankomati.UkloniMapObjekat(IMapObjekat mapObjekat)
        {
            throw new NotImplementedException();
        }

        public async Task UrediBankomat(Bankomat bankomat)
        {
            _context.Update(bankomat);
            await _context.SaveChangesAsync();
        }

        public async Task UrediFilijalu(Filijala filijala)
        {
            _context.Update(filijala);
            await _context.SaveChangesAsync();
        }
    }
}
