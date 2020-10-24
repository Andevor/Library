using Library.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public class KonyvtarRepository
    {
        private readonly konyvtarakContext entities = new konyvtarakContext();

        public void Create(Konyvtarak instance)
        {
            entities.Konyvtarak.Add(instance);
            entities.SaveChanges();
        }

        public IEnumerable<Konyvtarak> Read()
        {
            return entities.Konyvtarak.Select(x => x);
        }

        public void Update(Konyvtarak instance)
        {
            entities.Konyvtarak.Update(instance);
            entities.SaveChanges();
        }

        public void Delete(Konyvtarak instance)
        {
            entities.Konyvtarak.Remove(instance);
            entities.SaveChanges();
        }
    }
}
