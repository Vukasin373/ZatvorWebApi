using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class FirmaOdgovornaLicaView
    {
        public int Id { get; set; }
        public string OdgovornoLice { get; set; }
        public FirmaView Firma { get; set; }

        public FirmaOdgovornaLicaView(FirmaOdgovornaLica f)
        {
            Id = f.Id;
            OdgovornoLice = f.OdgovornoLice;
            Firma = new FirmaView(f.Firma);
        }
        public FirmaOdgovornaLicaView()
        {

        }
    }
}
