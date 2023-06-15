using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZaposleniView
    {
        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public char Pol { get; set; }
        public DateTime? DatumPPZ { get; set; }
        public string NazivRadnogMesta { get; set; }
        public string AStrucnaSprema { get; set; }
        public string AZanimanje { get; set; }
        public string APozicija { get; set; }
        public DateTime DatumPocetkaRada { get; set; }
        public ZatvorskaJedinicaView ZatvorskaJedinica { get; set; }
        public ZaposleniView()
        {

        }
        public ZaposleniView(Zaposleni z)
        {
            Id = z.Id;
            Jmbg = z.Jmbg;
            Ime = z.Ime;
            Prezime = z.Prezime;
            Pol = z.Pol;
            DatumPPZ = z.DatumPPZ;
            NazivRadnogMesta = z.NazivRadnogMesta;
            AStrucnaSprema = z.AStrucnaSprema;
            AZanimanje = z.AZanimanje;
            APozicija = z.APozicija;
            DatumPocetkaRada = z.DatumPocetkaRada;
            ZatvorskaJedinica = new ZatvorskaJedinicaView(z.ZatvorskaJedinica);
        }
    }
}
