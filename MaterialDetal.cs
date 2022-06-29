using System;
using System.Collections.Generic;

namespace projekt_p4_konsola
{
    public partial class MaterialDetal
    {
        public int? Idmaterialu { get; set; }
        public int? Idmostu { get; set; }
        public int? IloscMaterialu { get; set; }

        public virtual Material? IdmaterialuNavigation { get; set; }
        public virtual Most? IdmostuNavigation { get; set; }
    }
}
