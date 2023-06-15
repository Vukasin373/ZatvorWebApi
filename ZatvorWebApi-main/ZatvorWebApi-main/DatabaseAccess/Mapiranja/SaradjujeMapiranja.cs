using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class SaradjujeMapiranja : ClassMap<Saradjuje>
    {
        public SaradjujeMapiranja()
        {
            Table("SARADJUJE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Firma).Column("ID_FIRME").LazyLoad();
            References(x => x.ZatvorskaJedinica).Column("ID_ZATVORSKE_JEDINICE").LazyLoad();
        }
    }
}
