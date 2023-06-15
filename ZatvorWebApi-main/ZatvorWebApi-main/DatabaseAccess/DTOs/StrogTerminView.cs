using System;
using System.Collections.Generic;
using System.Text;
using Zatvor.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class StrogTerminView
    {
        public int Id { get; set; }
        public string TerminPosete { get; set; }
        public ZatvorskaJedinicaView Zatvor { get; set; }
        public StrogTerminView(StrogTerminPosete s)
        {
            Id = s.Id;
            TerminPosete = s.TerminPosete;
            Zatvor = new ZatvorskaJedinicaView(s.Zatvor);
        }
        public StrogTerminView()
        {

        }
    }
}
