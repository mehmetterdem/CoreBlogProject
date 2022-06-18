using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> ListAll(int id);
        List<T> ListAll();
        List<T> ListAll(Expression<Func<T, bool>> filter);

    }
}
