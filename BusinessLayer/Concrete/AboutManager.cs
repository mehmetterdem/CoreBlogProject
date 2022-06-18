using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About Get(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> ListAll(int id)
        {
            return _aboutDal.ListAll();
        }
        public List<About> ListAll()
        {
            return _aboutDal.ListAll();
        }

        public List<About> ListAll(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
