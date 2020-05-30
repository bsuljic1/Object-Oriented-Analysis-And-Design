using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.ZahtjevZaKreditRepository
{
    public class ZahtjeviZaKreditProxy : IZahtjeviZaKredit
    {
        int nivoPristupa = 2;
        IZahtjeviZaKredit zahtjevi;

        public ZahtjeviZaKreditProxy(OOADContext context)
        {
            zahtjevi = new ZahtjeviZaKredit(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Bankar)
                nivoPristupa = 2;
        }

        public Task<List<ZahtjevZaKredit>> DajSveZahtjeve()
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return zahtjevi.DajSveZahtjeve();
        }

        public async Task<ZahtjevZaKredit> DajZahtjev(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return await zahtjevi.DajZahtjev(id);
        }

        public bool DaLiPostojiZahtjev(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return zahtjevi.DaLiPostojiZahtjev(id);
        }

        public Task PodnesiZahtjevZaKredit(ZahtjevZaKredit zahtjevZaKredit)
        {
           // if (nivoPristupa != 3)
             //   throw new AuthenticationException();

            return zahtjevi.PodnesiZahtjevZaKredit(zahtjevZaKredit);
        }

        public Task RijesiZahtjev(int? id, bool prihvacen)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return zahtjevi.RijesiZahtjev(id, prihvacen);
        }

    }
}
