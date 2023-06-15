using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class DozvolaZaOruzje
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string SifraDozvole { get; set; }
        public virtual string PolicijskaUprava { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
    }
}
