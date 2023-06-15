using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class LekarskiPregledView
    {
        public int Id { get; set; }
        public string NazivUstanove { get; set; }
        public DateTime Datum { get; set; }
        public string AdresaUstanove { get; set; }
        public string Lekar { get; set; }
        public ZaposleniView Zaposleni { get; set; }

        public LekarskiPregledView()
        {

        }

        public LekarskiPregledView(LekarskiPregled l)
        {
            Id = l.Id;
            NazivUstanove = l.NazivUstanove;
            Datum = l.Datum;
            AdresaUstanove = l.AdresaUstanove;
            Lekar = l.Lekar;
            Zaposleni = new ZaposleniView(l.Zaposleni);
        }
    }
}
