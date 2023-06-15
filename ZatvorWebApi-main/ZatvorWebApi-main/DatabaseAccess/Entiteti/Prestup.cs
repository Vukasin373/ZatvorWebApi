using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Prestup
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string MinimalnaKazna { get; set; }
        public virtual string MaximalnaKazna { get; set; }
        public virtual string Kategorija { get; set; }

        public Prestup()
        {
        }
    }
}
