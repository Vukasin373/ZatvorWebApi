using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZOSTipaView : ZatvorskaJedinicaView
    {
        public ZOSTipaView()
        {

        }
        public ZOSTipaView(ZatvorskaJedinica z) : base(z)
        {
        }
    }
}
