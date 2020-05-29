using EBANK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    public class FilijaleBankomatiProxy : IFilijaleBankomati
    {
       //0 znaci da ne moze nista raditi sa filijalama i bankomatima, a 1 da moze sve
        int nivoPristupa = 1;
        IFilijaleBankomati filijaleBankomati;

        public FilijaleBankomatiProxy(OOADContext context)
        {
            filijaleBankomati = new FilijaleBankomati(context);
        }

        public void Pristupi(Korisnik korisnik)
        {
            if (korisnik is Administrator)
                nivoPristupa = 1;
        }

        public Task DodajBankomat(Bankomat bankomat)
        {
            if(nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.DodajBankomat(bankomat);
        }

        public Task UrediBankomat(Bankomat bankomat)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.UrediBankomat(bankomat);
        }

        public Task DodajFilijalu(Filijala filijala)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.DodajFilijalu(filijala);
        }

        public Task UrediFilijalu(Filijala filijala)
        {
            if (nivoPristupa != 1)
                throw new AuthenticationException();
            return filijaleBankomati.UrediFilijalu(filijala);
        }

        Task IFilijaleBankomati.UkloniMapObjekat(IMapObjekat mapObjekat)
        {
            throw new NotImplementedException();
        }

        Task<List<IMapObjekat>> IFilijaleBankomati.DajSveMapObjekte()
        {
            throw new NotImplementedException();
        }

        Task<IMapObjekat> IFilijaleBankomati.DajMapObjekat(int? id)
        {
            throw new NotImplementedException();
        }

        public bool DaLiPostojiMapObjekat(int? id)
        {
            throw new NotImplementedException();
        }

 

    }
}
