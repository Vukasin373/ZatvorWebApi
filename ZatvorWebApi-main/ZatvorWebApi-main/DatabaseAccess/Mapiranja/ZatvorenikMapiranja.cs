using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class ZatvorenikMapiranja : ClassMap<Zatvorenik>
    {
        public ZatvorenikMapiranja()
        {
            Table("ZATVORENIK");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Jmbg, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");
            Map(x => x.Broj, "BROJ");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.DatumSaslusanja, "DATUM_SASLUSANJA");
            Map(x => x.StatusUslovnogOtpusta, "STATUS_USLOVNOG_OTPUSTA");
           

            References(x => x.ZatvorskaJedinica).Column("ID_ZATVORSKE_JEDINICE").LazyLoad();
            HasMany(x => x.Zastupa).KeyColumn("ID_ZATVORENIKA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Posete).KeyColumn("ID_ZATVORENIKA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Prestupi).KeyColumn("ID_ZATVORENIKA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
