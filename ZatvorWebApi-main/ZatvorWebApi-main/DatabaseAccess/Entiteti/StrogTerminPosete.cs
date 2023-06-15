using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class StrogTerminPosete
    {
        public virtual int Id { get; set; }
        public virtual string TerminPosete { get; set; }
        public virtual ZatvorskaJedinica Zatvor { get; set; }
    }
}
