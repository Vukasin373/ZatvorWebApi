using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ZaposleniUpravnikView : ZaposleniView
    {
        public ZaposleniUpravnikView(Zaposleni z) : base(z)
        {
        }
        public ZaposleniUpravnikView()
        {

        }
    }
}
