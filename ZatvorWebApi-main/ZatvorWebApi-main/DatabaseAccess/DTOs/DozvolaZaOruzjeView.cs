using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class DozvolaZaOruzjeView
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string SifraDozvole { get; set; }
        public string PolicijskaUprava { get; set; }
        public ZaposleniView Zaposleni { get; set; }

        public DozvolaZaOruzjeView()
        {

        }

        public DozvolaZaOruzjeView(DozvolaZaOruzje d)
        {
            Id = d.Id;
            Datum = d.Datum;
            SifraDozvole = d.SifraDozvole;
            PolicijskaUprava = d.PolicijskaUprava;
            Zaposleni = new ZaposleniView(d.Zaposleni);
        }
    }
}
