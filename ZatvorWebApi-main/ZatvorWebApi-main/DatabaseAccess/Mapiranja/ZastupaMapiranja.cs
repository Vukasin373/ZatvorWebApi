using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class ZastupaMapiranja : ClassMap<Zastupa>
    {
        public ZastupaMapiranja()
        {
            Table("ZASTUPA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.ZastupaOd, "ZASTUPA_OD");
            Map(x => x.DatumPoslednjegKontakta, "DATUM_POSLEDNJEG_KONTAKTA");

            References(x => x.Zatvorenik).Column("ID_ZATVORENIKA").LazyLoad();
            References(x => x.Advokat).Column("ID_ADVOKATA").LazyLoad();
        }
    }
}
