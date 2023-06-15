using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class PosecujeMapiranja : ClassMap<Posecuje>
    {
        public PosecujeMapiranja()
        {
            Table("POSECUJE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.VremePocetka, "VREME_POCETKA");
            Map(x => x.VremeKraja, "VREME_KRAJA");

            References(x => x.Zatvorenik).Column("ID_ZATVORENIKA").LazyLoad();
            References(x => x.Advokat).Column("ID_ADVOKATA").LazyLoad();
        }
    }
}
