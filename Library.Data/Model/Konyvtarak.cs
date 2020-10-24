using System;
using System.Collections.Generic;

namespace Library.Data.Model
{
    public partial class Konyvtarak
    {
        public int Id { get; set; }
        public string KonyvtarNev { get; set; }
        public string Irsz { get; set; }
        public string Cim { get; set; }

        public virtual Telepulesek IrszNavigation { get; set; }

        public override string ToString()
        {
            return KonyvtarNev;
        }
    }
}
