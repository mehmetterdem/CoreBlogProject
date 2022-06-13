using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        public void Add(T Entity)
        {
            c.Add(Entity);
            c.SaveChanges();
        }

        public void Delete(T Entity)
        {
            c.Remove(Entity);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> ListAll()
        {
            return c.Set<T>().ToList();
        }

        public void Update(T Entity)
        {
            c.Update(Entity);
            c.SaveChanges();
        }
    }
}
