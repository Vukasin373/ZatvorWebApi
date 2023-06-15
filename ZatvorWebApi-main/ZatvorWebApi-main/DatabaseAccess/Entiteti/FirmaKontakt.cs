using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class FirmaKontakt
    {
        public virtual int Id { get; set; }
        public virtual string KontaktTelefon { get; set; }
        public virtual Firma Firma { get; set; }
    }
}
