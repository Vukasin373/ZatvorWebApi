using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class LekarskiPregled
    {
        public virtual int Id { get; set; }
        public virtual string NazivUstanove { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string AdresaUstanove { get; set; }
        public virtual string Lekar { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
    }
}
