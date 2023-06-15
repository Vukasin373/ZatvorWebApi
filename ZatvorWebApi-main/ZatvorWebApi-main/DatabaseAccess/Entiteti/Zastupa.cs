using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Zastupa
    {
        public virtual int Id { get; set; }
        public virtual DateTime ZastupaOd { get; set; }
        public virtual DateTime DatumPoslednjegKontakta { get; set; }
        public virtual Zatvorenik Zatvorenik { get; set; }
        public virtual Advokat Advokat { get; set; }
    }
}
