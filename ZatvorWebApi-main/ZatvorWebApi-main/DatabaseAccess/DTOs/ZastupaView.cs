using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZastupaView
    {
        public int Id { get; set; }
        public DateTime ZastupaOd { get; set; }
        public DateTime DatumPoslednjegKontakta { get; set; }
        public ZatvorenikView Zatvorenik { get; set; }
        public AdvokatView Advokat { get; set; }

        public ZastupaView(Zastupa z)
        {
            Id = z.Id;
            ZastupaOd = z.ZastupaOd;
            DatumPoslednjegKontakta = z.DatumPoslednjegKontakta;
            Zatvorenik = new ZatvorenikView(z.Zatvorenik);
            Advokat = new AdvokatView(z.Advokat);
        }
        public ZastupaView()
        {

        }
    }
}
