﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    internal class AboutManager : IAboutService
    {
        public void Add(About entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(About entity)
        {
            throw new NotImplementedException();
        }

        public About Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<About> ListAll()
        {
            throw new NotImplementedException();
        }

        public List<About> ListAll(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> ListAll(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
