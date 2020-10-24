using Library.Data;
using Library.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Logic
{
    public class KonyvtarLogic
    {
        KonyvtarRepository repo;
        List<Konyvtarak> elements;

        public KonyvtarLogic()
        {
            repo = new KonyvtarRepository();
            elements = repo.Read().ToList();
        }

        public void Create(Konyvtarak instance)
        {
            elements.Add(instance);
            repo.Create(instance);
        }

        public IEnumerable<Konyvtarak> Read()
        {
            return elements;
        }

        public void Update(Konyvtarak instance)
        {
            elements[elements.IndexOf(elements.Find(x => x.Id == instance.Id))] = instance;
            repo.Update(instance);
        }

        public void Delete(Konyvtarak instance)
        {
            elements.Remove(instance);
            repo.Delete(instance);
        }
    }
}
