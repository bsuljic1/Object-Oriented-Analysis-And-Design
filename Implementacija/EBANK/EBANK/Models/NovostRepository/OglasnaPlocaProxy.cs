using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.NovostRepository
{
    public class OglasnaPlocaProxy : IOglasnaPloca
    {
        //0 - nista, 1 - samo pregledanje, 2 - pregledanje i uredjivanje
        int nivoPristupa = 2;
        IOglasnaPloca OglasnaPloca;

        public OglasnaPlocaProxy(OOADContext context)
        {
            OglasnaPloca = new OglasnaPloca(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Bankar)
                nivoPristupa = 2;
        }

        public Task DodajNovost(Novost novost)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return OglasnaPloca.DodajNovost(novost);
        }

        public Task UkloniNovost(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return OglasnaPloca.UkloniNovost(id);
        }

        public Task UrediNovost(Novost novost)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return OglasnaPloca.UrediNovost(novost);
        }

        public Task<List<Novost>> DajSveNovosti()
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return OglasnaPloca.DajSveNovosti();
        }

        public async Task<Novost> DajNovost(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return await OglasnaPloca.DajNovost(id);
        }

        public bool DaLiPostojiNovost(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
