using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZOTipaView : ZatvorskaJedinicaView
    {
        public ZOTipaView()
        {

        }
        public ZOTipaView(ZatvorskaJedinica z) : base(z)
        {
        }
    }
}
