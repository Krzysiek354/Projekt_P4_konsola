using System;
using System.Collections.Generic;

namespace projekt_p4_konsola
{
    public partial class Przeglad
    {
        public int Idprzegladu { get; set; }
        public DateTime DataPrzegladu { get; set; }
        public string ZakresPrzegladu { get; set; } = null!;
        public string WykonujacyPrzegladImie { get; set; } = null!;
        public string WykonujacyPrzegladNazwisko { get; set; } = null!;
        public string? Zalecenia { get; set; }
        public int? Idmostu { get; set; }

        public virtual Most? IdmostuNavigation { get; set; }
    }
}
