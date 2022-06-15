using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {


        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        List<T> ListAll();
        T GetById(int id);

        List<T> ListAll(Expression<Func<T, bool>> filter);
    }
}
