using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class FirmaView
    {
        virtual public int Id { get; protected set; }
        virtual public string Pib { get; set; }
        virtual public string ImeFirme { get; set; }
        //public virtual IList<ZatvorskaJedinicaView> ZatvorskeJedinice { get; set; }
        //public virtual IList<FirmaKontaktView> Kontakt { get; set; }
        //public virtual IList<FirmaOdgovornaLicaView> OdgovornaLica { get; set; }

        public FirmaView()
        {

        }
        public FirmaView(Firma f)
        {
            Id = f.Id;
            Pib = f.Pib;
            ImeFirme = f.ImeFirme;
        }

    }
}
