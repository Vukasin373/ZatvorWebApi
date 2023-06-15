using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class FirmaKontaktView
    {
        public int Id { get; set; }
        public string KontaktTelefon { get; set; }
        public FirmaView Firma { get; set; }

        public FirmaKontaktView(FirmaKontakt f)
        {
            Id = f.Id;
            KontaktTelefon = f.KontaktTelefon;
            Firma = new FirmaView(f.Firma);
        }
        public FirmaKontaktView()
        {

        }
    }
}
