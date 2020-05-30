using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.KreditRepository
{
    public class KreditiProxy : IKrediti
    {
        int nivoPristupa = 2;
        IKrediti krediti;

        public KreditiProxy(OOADContext context)
        {
            krediti = new Krediti(context);
        }


        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
            else if (korisnik is Bankar)
                nivoPristupa = 2;
            else if (korisnik is Klijent)
                nivoPristupa = 3;
        }


        public async Task<Kredit> DajKredit(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return await krediti.DajKredit(id);
        }

        public Task<List<Kredit>> DajSveKredite()
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return krediti.DajSveKredite();
        }

        public bool DaLiPostojiKredit(int? id)
        {
            if (nivoPristupa == 0)
                throw new AuthenticationException();

            return krediti.DaLiPostojiKredit(id);
        }

    }
}
