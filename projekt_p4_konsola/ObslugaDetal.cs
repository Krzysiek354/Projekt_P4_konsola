using System;
using System.Collections.Generic;

namespace projekt_p4_konsola
{
    public partial class ObslugaDetal
    {
        public int? Idmostu { get; set; }
        public int? NumerKwalifikacji { get; set; }

        public virtual Most? IdmostuNavigation { get; set; }
        public virtual OsobaObslugujaca? NumerKwalifikacjiNavigation { get; set; }
    }
}
