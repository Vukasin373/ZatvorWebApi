using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Entiteti
{
    public class Zatvorenik
    {
		public virtual int Id { get; set; }
		public virtual string Jmbg { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual char Pol { get; set; }
		public virtual string Broj { get; set; }
		public virtual string Adresa { get; set; }
		public virtual DateTime? DatumSaslusanja { get; set; }
		public virtual char StatusUslovnogOtpusta { get; set; }
		public virtual ZatvorskaJedinica ZatvorskaJedinica { get; set; }
		public virtual IList<Zastupa> Zastupa { get; set; }
		public virtual IList<Posecuje> Posete { get; set; }
        public virtual IList<Pocinio> Prestupi{ get; set; }

        public Zatvorenik()
        {
			Zastupa = new List<Zastupa>();
			Posete = new List<Posecuje>();
			Prestupi = new List<Pocinio>();
		}
	}
}