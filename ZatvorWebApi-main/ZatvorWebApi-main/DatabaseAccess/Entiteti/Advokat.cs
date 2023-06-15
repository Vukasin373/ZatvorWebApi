using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Advokat
    {
		public virtual int Id { get; set; }
		public virtual string Jmbg { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual char Pol { get; set; }
		//public virtual IList<Zastupa> Zastupa { get; set; }
		//public virtual IList<Posecuje> Posete { get; set; }
		public Advokat()
        {
			//Zastupa = new List<Zastupa>();
			//Posete = new List<Posecuje>();
		}
	}
}

