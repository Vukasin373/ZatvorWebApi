using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class DozvolaZaOruzjeMapiranja : ClassMap<DozvolaZaOruzje>
    {
        public DozvolaZaOruzjeMapiranja()
        {
            Table("DOZVOLA_ZA_ORUZJE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Datum, "DATUM");
            Map(x => x.SifraDozvole, "SIFRA_DOZVOLE");
            Map(x => x.PolicijskaUprava, "POLICIJSKA_UPRAVA");

            References(x => x.Zaposleni).Column("ID_ZAPOSLENOG").LazyLoad();
        }
    }
}
