using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class AdvokatView
    {
		public virtual int Id { get; set; }
		public virtual string Jmbg { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual char Pol { get; set; }
		//public virtual IList<ZastupaView> Zastupa { get; set; }
		//public virtual IList<PosecujeView> Posete { get; set; }

		public AdvokatView()
        {

        }
		public AdvokatView(Advokat a)
		{
			Id = a.Id;
			Jmbg = a.Jmbg;
			Ime = a.Ime;
			Prezime = a.Prezime;
			Pol = a.Pol;
		}
	}
}
