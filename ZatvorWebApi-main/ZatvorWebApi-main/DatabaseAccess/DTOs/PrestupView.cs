using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class PrestupView
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string MinimalnaKazna { get; set; }
        public virtual string MaximalnaKazna { get; set; }
        public virtual string Kategorija { get; set; }
        public virtual IList<Pocinio> Zatvorenici { get; set; }

        PrestupView()
        {

        }
        public PrestupView(Prestup p)
        {
            Id = p.Id;
            Naziv = p.Naziv;
            Opis = p.Opis;
            MinimalnaKazna = p.MinimalnaKazna;
            MaximalnaKazna = p.MaximalnaKazna;
            Kategorija = p.Kategorija;
        }
    }
}
