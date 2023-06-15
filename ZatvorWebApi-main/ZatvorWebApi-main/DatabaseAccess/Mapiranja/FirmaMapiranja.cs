using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{


    class FirmaMapiranja : ClassMap<Firma>
    {
        public FirmaMapiranja()
        {
            //Mapiranje tabele
            Table("FIRMA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Pib, "PIB");
            Map(x => x.ImeFirme, "IME_FIRME");

            //HasMany(x => x.Kontakt).KeyColumn("ID_FIRME").LazyLoad().Cascade.All().Inverse();
            //HasMany(x => x.OdgovornaLica).KeyColumn("ID_FIRME").LazyLoad().Cascade.All().Inverse();

            //HasManyToMany(x => x.ZatvorskeJedinice)
            //.Table("SARADJUJE")
            //.ParentKeyColumn("ID_FIRME")
            //.ChildKeyColumn("ID_ZATVORSKE_JEDINICE")
            //.Cascade.All();

        }
    }
   
}
