using EBANK.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.ZahtjevZaKreditRepository
{
    public class ZahtjeviZaKredit : IZahtjeviZaKredit
    {
        private OOADContext _context;

        public ZahtjeviZaKredit(OOADContext context)
        {
            _context = context;
        }
        public async Task<List<ZahtjevZaKredit>> DajSveZahtjeve()
        {
            return await _context.ZahtjevZaKredit.ToListAsync();
        }

        public async Task<ZahtjevZaKredit> DajZahtjev(int? id)
        {
            ZahtjevZaKredit zahtjev = await _context.ZahtjevZaKredit.FindAsync(id);
            return zahtjev;
        }

        public bool DaLiPostojiZahtjev(int? id)
        {
            return _context.ZahtjevZaKredit.Any(e => e.Id == id);
        }

        public Task PodnesiZahtjevZaKredit(ZahtjevZaKredit zahtjevZaKredit)
        {
            throw new NotImplementedException();
        }

        public async Task RijesiZahtjev(int? id, bool prihvacen)
        {
            ZahtjevZaKredit zahtjev = await _context.ZahtjevZaKredit.FindAsync(id);
            if(prihvacen) zahtjev.StatusZahtjeva = StatusZahtjevaZaKredit.Odobren;
            else zahtjev.StatusZahtjeva = StatusZahtjevaZaKredit.Odbijen;
            _context.ZahtjevZaKredit.Update(zahtjev);
            await _context.SaveChangesAsync();
        }

    }
}
