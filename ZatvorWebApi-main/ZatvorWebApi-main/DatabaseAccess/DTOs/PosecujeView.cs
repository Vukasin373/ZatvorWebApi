using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PosecujeView
    {
        public int Id { get; set; }
        public DateTime VremePocetka { get; set; }
        public DateTime VremeKraja { get; set; }
        public ZatvorenikView Zatvorenik { get; set; }
        public AdvokatView Advokat { get; set; }
        public PosecujeView(Posecuje p)
        {
            Id = p.Id;
            VremePocetka = p.VremePocetka;
            VremeKraja = p.VremeKraja;
            Zatvorenik = new ZatvorenikView(p.Zatvorenik);
            Advokat = new AdvokatView(p.Advokat);
        }
        public PosecujeView()
        {

        }
    }
}
