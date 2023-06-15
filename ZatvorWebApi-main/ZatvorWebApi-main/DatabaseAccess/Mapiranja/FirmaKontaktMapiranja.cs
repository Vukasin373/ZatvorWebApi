using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class FirmaKontaktMapiranja : ClassMap<FirmaKontakt>
    {
        public FirmaKontaktMapiranja()
        {
            //Mapiranje tabele
            Table("FIRMA_KONTAKT");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.KontaktTelefon, "KONTAKT_TELEFON");

            References(x => x.Firma).Column("ID_FIRME").LazyLoad();
        }
    }
}
