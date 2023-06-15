using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor.Mapiranja
{
    class PrestupMapiranja : ClassMap<Prestup>
    {
        public PrestupMapiranja()
        {
            Table("PRESTUP");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Opis, "OPIS");
            Map(x => x.MinimalnaKazna, "MINIMALNA_KAZNA");
            Map(x => x.MaximalnaKazna, "MAXIMALNA_KAZNA");
            Map(x => x.Kategorija, "KATEGORIJA");

        }
    }
}
