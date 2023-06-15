using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Pocinio
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum { get; set; }
        public virtual string MestoPrestupa { get; set; }
        public virtual Zatvorenik Zatvorenik { get; set; }
        public virtual Prestup Prestup { get; set; }
    }
}
