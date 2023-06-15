using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZaposlenUAdministracijaView : ZaposleniView
    {
        public ZaposlenUAdministracijaView(Zaposleni z) : base(z)
        {
        }
        public ZaposlenUAdministracijaView()
        {

        }
    }
}
