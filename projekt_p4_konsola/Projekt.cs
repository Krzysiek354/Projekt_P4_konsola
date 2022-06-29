using System;
using System.Collections.Generic;

namespace projekt_p4_konsola
{
    public partial class Projekt
    {
        public Projekt()
        {
            Mosts = new HashSet<Most>();
        }

        public int NumerProjektu { get; set; }
        public DateTime DataProjektu { get; set; }
        public string AutorProjektuImie { get; set; } = null!;
        public string AutorProjektuNazwisko { get; set; } = null!;
        public string? Rodzaj { get; set; }

        public virtual ICollection<Most> Mosts { get; set; }
    }
}
