using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Firma
    {
        public virtual int Id { get; protected set; }
        public virtual string Pib { get; set; }
        public virtual string ImeFirme { get; set; }
        //public virtual IList<ZatvorskaJedinica> ZatvorskeJedinice { get; set; }
        //public virtual IList<FirmaKontakt> Kontakt { get; set; }
        //public virtual IList<FirmaOdgovornaLica> OdgovornaLica { get; set; }
        public Firma()
        {
        //    ZatvorskeJedinice = new List<ZatvorskaJedinica>();
        //    Kontakt = new List<FirmaKontakt>();
        //    OdgovornaLica = new List<FirmaOdgovornaLica>();
        }
    }
}
