using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZatvorenikView
    {
		public int Id { get; set; }
		public string Jmbg { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public char Pol { get; set; }
		public string Broj { get; set; }
		public string Adresa { get; set; }
		public DateTime? DatumSaslusanja { get; set; }
		public char StatusUslovnogOtpusta { get; set; }
		public ZatvorskaJedinicaView ZatvorskaJedinica { get; set; }
		public IList<ZastupaView> Zastupa { get; set; }
		public IList<PosecujeView> Posete { get; set; }
		public IList<PocinioView> Prestupi { get; set; }

        public ZatvorenikView()
        {

        }

		public ZatvorenikView(Zatvorenik z)
        {
			Id = z.Id;
			Jmbg = z.Jmbg;
			Ime = z.Ime;
			Prezime = z.Prezime;
			Pol = z.Pol;
			Broj = z.Broj;
			Adresa = z.Adresa;
			DatumSaslusanja = z.DatumSaslusanja;
			StatusUslovnogOtpusta = z.StatusUslovnogOtpusta;
        }
	}
}
