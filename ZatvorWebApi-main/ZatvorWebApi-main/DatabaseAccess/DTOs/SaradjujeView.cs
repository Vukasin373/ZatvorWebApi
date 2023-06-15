using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class SaradjujeView
    {
        public int Id { get; set; }
        public FirmaView Firma { get; set; }
        public ZatvorskaJedinicaView ZatvorskaJedinica { get; set; }
        public SaradjujeView(Saradjuje s)
        {
            Id = s.Id;
            Firma = new FirmaView(s.Firma);
            ZatvorskaJedinica = new ZatvorskaJedinicaView(  s.ZatvorskaJedinica);
        }
        public SaradjujeView()
        {

        }
    }
}
