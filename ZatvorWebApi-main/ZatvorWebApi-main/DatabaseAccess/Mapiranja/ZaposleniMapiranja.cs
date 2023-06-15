using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class ZaposleniMapiranja : ClassMap<Zaposleni>
    {
        public ZaposleniMapiranja()
        {
            Table("ZAPOSLENI");

            //mapiranje podklasa
            DiscriminateSubClassesOnColumn("NAZIV_RADNOG_MESTA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Jmbg, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");
            Map(x => x.DatumPPZ, "DATUM_PPZ");
            Map(x => x.AStrucnaSprema, "A_STRUCNA_SPREMA");
            Map(x => x.AZanimanje, "A_ZANIMANJE");
            Map(x => x.APozicija, "A_POZICIJA");
            Map(x => x.DatumPocetkaRada, "DATUM_POCETKA_RADA");

            References(x => x.ZatvorskaJedinica).Column("ID_ZATVORSKE_JEDINICE").LazyLoad();

        }
    }
    class UpravnikMapiranja : SubclassMap<Upravnik>
    {
        public UpravnikMapiranja()
        {
            DiscriminatorValue("Upravnik");
        }
    }

    class ZaposlenUAdministracijiMapiranja : SubclassMap<ZaposlenUAdministraciji>
    {
        public ZaposlenUAdministracijiMapiranja()
        {
            DiscriminatorValue("Administracija");
        }
    }

    class PsihologMapiranja : SubclassMap<Psiholog>
    {
        public PsihologMapiranja()
        {
            DiscriminatorValue("Psiholog");
        }
    }

    class Radnik_obezbedjenjaMapiranja : SubclassMap<Radnik_obezbedjenja>
    {
        public Radnik_obezbedjenjaMapiranja()
        {
            DiscriminatorValue("Obezbedjenje");
        }
    }
}
