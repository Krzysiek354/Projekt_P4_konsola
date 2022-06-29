using System;
using System.Collections.Generic;

namespace projekt_p4_konsola
{
    public partial class Most
    {
        public Most()
        {
            Przeglads = new HashSet<Przeglad>();
        }

        public int Idmostu { get; set; }
        public string? WspolrzedneDl { get; set; }
        public string? WspolrzedneSzer { get; set; }
        public string DaneTechniczne { get; set; } = null!;
        public DateTime? DataPowstania { get; set; }
        public string TypMostu { get; set; } = null!;
        public string NazwaMostu { get; set; } = null!;
        public int? NumerProjektu { get; set; }

        public virtual Projekt? NumerProjektuNavigation { get; set; }
        public virtual ICollection<Przeglad> Przeglads { get; set; }
    }
}
