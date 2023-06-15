using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class StrogTerminPoseteMapiranja : ClassMap<StrogTerminPosete>
    {
        public StrogTerminPoseteMapiranja()
        {
            //Mapiranje tabele
            Table("STROG_TERMIN_POSETE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.TerminPosete, "TERMIN_POSETE");

            References(x => x.Zatvor).Column("ID_ZATVORSKE_JEDINICE").LazyLoad();
        }
    }
}
