using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class PocinioMapiranja : ClassMap<Pocinio>
    {
        public PocinioMapiranja()
        {
            Table("POCINIO");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Datum, "DATUM");
            Map(x => x.MestoPrestupa, "MESTO_PRESTUPA");

            References(x => x.Zatvorenik).Column("ID_ZATVORENIKA").LazyLoad();
            References(x => x.Prestup).Column("ID_PRESTUPA").LazyLoad();
        }
    }
}
