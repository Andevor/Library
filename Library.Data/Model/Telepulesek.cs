using System;
using System.Collections.Generic;

namespace Library.Data.Model
{
    public partial class Telepulesek
    {
        public Telepulesek()
        {
            Konyvtarak = new HashSet<Konyvtarak>();
        }

        public string Irsz { get; set; }
        public string TelepNev { get; set; }
        public int MegyeId { get; set; }

        public virtual Megyek Megye { get; set; }
        public virtual ICollection<Konyvtarak> Konyvtarak { get; set; }
    }
}
