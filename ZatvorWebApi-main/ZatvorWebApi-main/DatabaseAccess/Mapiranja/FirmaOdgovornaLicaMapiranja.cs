using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class FirmaOdgovornaLicaMapiranja : ClassMap<FirmaOdgovornaLica>
    {
        public FirmaOdgovornaLicaMapiranja()
        {
            //Mapiranje tabele
            Table("FIRMA_ODGOVORNA_LICA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.OdgovornoLice, "ODGOVORNO_LICE");

            References(x => x.Firma).Column("ID_FIRME").LazyLoad();
        }
    }
}
