using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;
using FluentNHibernate.Mapping;
using DatabaseAccess.DTOs;

namespace Zatvor.Mapiranja
{
    class ZatvorskaJedinicaMapiranja : ClassMap<ZatvorskaJedinica>
    {
        public ZatvorskaJedinicaMapiranja()
        {
            Table("ZATVORSKA_JEDINICA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Sifra, "SIFRA");
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Kapacitet, "KAPACITET");
            Map(x => x.OtvoreniF, "OTVORENI_F");
            Map(x => x.PoluOtvoreniF, "POLUOTVORENI_F");
            Map(x => x.PeriodZakljucavanja, "PERIOD_ZAKLJUCAVANJA");
            Map(x => x.StrogiF, "STROGI_F");
            Map(x => x.Setnja, "SETNJA");

            DiscriminateSubClassesOnColumn("")
                .Formula(
                "CASE " +
                " WHEN (OTVORENI_F = 'Y' AND POLUOTVORENI_F = 'N' AND STROGI_F = 'N') THEN 'O' " +
                " WHEN (OTVORENI_F = 'N' AND POLUOTVORENI_F = 'Y' AND STROGI_F = 'N') THEN 'PO' " +
                " WHEN (OTVORENI_F = 'N' AND POLUOTVORENI_F = 'N' AND STROGI_F = 'Y') THEN 'S' " +
                " WHEN (OTVORENI_F = 'Y' AND POLUOTVORENI_F = 'Y' AND STROGI_F = 'N') THEN 'OPO' " +
                " WHEN (OTVORENI_F = 'Y' AND POLUOTVORENI_F = 'N' AND STROGI_F = 'Y') THEN 'OS' " +
                " WHEN (OTVORENI_F = 'N' AND POLUOTVORENI_F = 'Y' AND STROGI_F = 'Y') THEN 'POS' " +
                " WHEN (OTVORENI_F = 'Y' AND POLUOTVORENI_F = 'Y' AND STROGI_F = 'Y') THEN 'OPOS' " +
                " END");

            References(x => x.Upravnik).Column("ID_UPRAVNIKA").LazyLoad();
            HasMany(x => x.Zatvorenici).KeyColumn("ID_ZATVORSKE_JEDINICE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Zaposleni).KeyColumn("ID_ZATVORSKE_JEDINICE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.TerminiPosete).KeyColumn("ID_ZATVORSKE_JEDINICE").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Firme)
                .Table("SARADJUJE")
                .ParentKeyColumn("ID_ZATVORSKE_JEDINICE")
                .ChildKeyColumn("ID_FIRME")
                .Cascade.All()
                .Inverse();
        }
    }
    class ZOTipaMapiranja   : SubclassMap<ZOTipa>
    {
        public ZOTipaMapiranja()
        {
            DiscriminatorValue("O");
        }
    }
    class ZPOTipaMapiranja  : SubclassMap<ZPOTipa>
    {
        public ZPOTipaMapiranja()
        {
            DiscriminatorValue("PO");
        }
    }
    class ZSTipaMapiranja   : SubclassMap<ZSTipa>
    {
        public ZSTipaMapiranja()
        {
            DiscriminatorValue("S");
        }
    }
    class ZOPOTipaMapiranja : SubclassMap<ZOPOTipa>
    {
        public ZOPOTipaMapiranja()
        {
            DiscriminatorValue("OPO");
        }
    }
    class ZOSTipaMapiranja : SubclassMap<ZOSTipa>
    {
        public ZOSTipaMapiranja()
        {
            DiscriminatorValue("OS");
        }
    }
    class ZPOSTipaMapiranja : SubclassMap<ZPOSTipa>
    {
        public ZPOSTipaMapiranja()
        {
            DiscriminatorValue("POS");
        }
    }
    class ZOPOSTipaMapiranja : SubclassMap<ZOPOSTipa>
    {
        public ZOPOSTipaMapiranja()
        {
            DiscriminatorValue("OPOS");
        }
    }
}
