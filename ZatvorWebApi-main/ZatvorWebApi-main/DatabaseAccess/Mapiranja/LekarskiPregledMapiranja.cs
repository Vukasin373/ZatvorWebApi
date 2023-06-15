using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class LekarskiPregledMapiranja : ClassMap<LekarskiPregled>
    {
        public LekarskiPregledMapiranja()
        {
            Table("LEKARSKI_PREGLED");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.NazivUstanove, "NAZIV_USTANOVE");
            Map(x => x.Datum, "DATUM");
            Map(x => x.AdresaUstanove, "ADRESA_USTANOVE");
            Map(x => x.Lekar, "LEKAR");

            References(x => x.Zaposleni).Column("ID_ZAPOSLENOG").LazyLoad();
        }
    }
}
