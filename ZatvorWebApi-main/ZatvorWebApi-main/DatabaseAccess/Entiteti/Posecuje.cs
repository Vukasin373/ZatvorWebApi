using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Posecuje
    {
        public virtual int Id { get; set; }
        public virtual DateTime VremePocetka { get; set; }
        public virtual DateTime VremeKraja { get; set; }
        public virtual Zatvorenik Zatvorenik { get; set; }
        public virtual Advokat Advokat { get; set; }
    }
}
