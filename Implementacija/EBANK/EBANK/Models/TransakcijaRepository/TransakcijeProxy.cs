using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    public class TransakcijeProxy : ITransakcije
    {
        //0 ne moze nista, 1 moze samo pregledati, a 2 moze uplacivati
        private int nivoPristupa = 2;
        private readonly ITransakcije transakcije;

        public TransakcijeProxy(OOADContext context)
        {
            transakcije = new Transakcije(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Klijent) nivoPristupa = 2;
            else if (korisnik is Bankar) nivoPristupa = 1;
            else nivoPristupa = 0;
        }
        public Task<List<Transakcija>> DajSveTransakcije()
        {
            if(nivoPristupa == 0) throw new AuthenticationException();
            return transakcije.DajSveTransakcije();
        }

        public Task<Transakcija> DajTransakciju(int? id)
        {
            if (nivoPristupa == 0) throw new AuthenticationException();
            return transakcije.DajTransakciju(id);
        }

        public Task Uplati(Transakcija transakcija)
        {
            if (nivoPristupa != 2) throw new AuthenticationException();
            return transakcije.Uplati(transakcija);
        }

        public bool DaLiPostojiTransakcija(int? id)
        {
            return transakcije.DaLiPostojiTransakcija(id);
        }
    }
}
