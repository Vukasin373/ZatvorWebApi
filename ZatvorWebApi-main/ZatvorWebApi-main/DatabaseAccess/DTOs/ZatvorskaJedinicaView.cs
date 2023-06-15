using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZatvorskaJedinicaView
    {
		public int Id { get; set; }
		public string Sifra { get; set; }
		public string Naziv { get; set; }
		public string Adresa { get; set; }
		public int Kapacitet { get; set; }
		public char OtvoreniF { get; set; }
		public char PoluOtvoreniF { get; set; }
		public string PeriodZakljucavanja { get; set; }
		public char StrogiF { get; set; }
		public string Setnja { get; set; }
		public ZaposleniUpravnikView Upravnik { get; set; }
		public IList<Zatvorenik> Zatvorenici { get; set; }
		public IList<Zaposleni> Zaposleni { get; set; }
		public IList<Firma> Firme { get; set; }
		public IList<StrogTerminPosete> TerminiPosete { get; set; }
        public ZatvorskaJedinicaView()
        {
				
        }
        public ZatvorskaJedinicaView(ZatvorskaJedinica z)
        {
			Id = z.Id;
			Sifra = z.Sifra;
			Naziv = z.Naziv;
			Adresa = z.Adresa;
			Kapacitet = z.Kapacitet;
			OtvoreniF = z.OtvoreniF;
			PoluOtvoreniF = z.PoluOtvoreniF;
			PeriodZakljucavanja = z.PeriodZakljucavanja;
			StrogiF = z.StrogiF;
			Setnja = z.Setnja;
        }
	}
}
