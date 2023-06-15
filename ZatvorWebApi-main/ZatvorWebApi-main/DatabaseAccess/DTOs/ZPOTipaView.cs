using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZPOTipaView : ZatvorskaJedinicaView
    {
        public ZPOTipaView()
        {

        }
        public ZPOTipaView(ZatvorskaJedinica z) : base(z)
        {
        }
    }
}
