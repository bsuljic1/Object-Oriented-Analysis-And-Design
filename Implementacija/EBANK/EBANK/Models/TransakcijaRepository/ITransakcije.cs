using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Models.TransakcijaRepository
{
    interface ITransakcije
    {
        public Task Uplati(Racun saRacuna, Racun naRacun, float iznos);
        public Task<List<Transakcija>> DajSveTransakcije();
        public Task<Transakcija> DajTransakciju(int? id);
        bool DaLiPostojiTransakcija(int? id);
    }
}
