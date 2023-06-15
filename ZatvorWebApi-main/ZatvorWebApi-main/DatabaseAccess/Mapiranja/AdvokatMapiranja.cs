using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class AdvokatMapiranja : ClassMap<Advokat>
    {
        public AdvokatMapiranja()
        {
            Table("ADVOKAT");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Jmbg, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");

            //HasMany(x => x.Zastupa).KeyColumn("ID_ADVOKATA").LazyLoad().Cascade.All().Inverse();
            //HasMany(x => x.Posete).KeyColumn("ID_ADVOKATA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
