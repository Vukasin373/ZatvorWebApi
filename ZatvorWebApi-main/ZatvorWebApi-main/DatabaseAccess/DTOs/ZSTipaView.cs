using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZSTipaView : ZatvorskaJedinicaView
    {
        public ZSTipaView()
        {

        }
        public ZSTipaView(ZatvorskaJedinica z) : base(z)
        {
        }
    }
}
