using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.RacunRepository
{
    public class RacuniProxy : IRacuni
    {
        //0 - nista, 1 - samo pregledanje, 2 - pregledanje i uredjivanje
        int nivoPristupa = 2;
        IRacuni racuni;

        public RacuniProxy(OOADContext context)
        {
            racuni = new Racuni(context);
        }

       

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Bankar)
                nivoPristupa = 2;
        }

        public Task OtvoriRacun(Racun racun)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return racuni.OtvoriRacun(racun);
        }

        public Task ZatvoriRacun(int? id)
        {
            if (nivoPristupa != 2)
                throw new AuthenticationException();

            return racuni.ZatvoriRacun(id);
        }


        public Task<List<Racun>> DajSveRacune()
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return racuni.DajSveRacune();
        }

        public async Task<Racun> DajRacun(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return await racuni.DajRacun(id);
        }
        public bool DaLiPostojiRacun(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return racuni.DaLiPostojiRacun(id);
        }

        public async Task<List<Racun>> DajSveRacuneKlijenta(int? id)
        {
            return await racuni.DajSveRacuneKlijenta(id);
        }
    }
}

