using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.FilijaleBankomatiRepository
{
    interface IFilijaleBankomati
    {
        public Task DodajBankomat(Bankomat bankomat);
        public Task UrediBankomat(Bankomat bankomat);
        public Task DodajFilijalu(Filijala filijala);
        public Task UrediFilijalu(Filijala filijala);
        public Task UkloniMapObjekat(IMapObjekat mapObjekat);
        public Task<List<IMapObjekat>> DajSveMapObjekte();
        public Task<IMapObjekat> DajMapObjekat(int? id);
        public bool DaLiPostojiMapObjekat(int? id);
        
    }
}
