using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PocinioView
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string MestoPrestupa { get; set; }
        public ZatvorenikView Zatvorenik { get; set; }
        public PrestupView Prestup { get; set; }

        public PocinioView(Pocinio p)
        {
            Id = p.Id;
            Datum = p.Datum;
            MestoPrestupa = p.MestoPrestupa;
            Zatvorenik = new ZatvorenikView(p.Zatvorenik);
            Prestup = new PrestupView(p.Prestup);
        }
        public PocinioView()
        {

        }
    }
}
