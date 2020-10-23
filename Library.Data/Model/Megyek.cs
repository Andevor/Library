using System;
using System.Collections.Generic;

namespace Library.Data.Model
{
    public partial class Megyek
    {
        public Megyek()
        {
            Telepulesek = new HashSet<Telepulesek>();
        }

        public int Id { get; set; }
        public string MegyeNev { get; set; }

        public virtual ICollection<Telepulesek> Telepulesek { get; set; }
    }
}
