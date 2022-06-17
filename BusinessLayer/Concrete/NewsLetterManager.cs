using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetter;

        public NewsLetterManager(INewsLetterDal newsLetter)
        {
            _newsLetter = newsLetter;
        }

        public void Add(NewsLetter entity)
        {
            _newsLetter.Add(entity);
        }

        public void Delete(NewsLetter entity)
        {
            _newsLetter?.Delete(entity);
        }

        public NewsLetter Get(int id)
        {
            return _newsLetter.GetById(id);
        }

        public List<NewsLetter> ListAll(int id)
        {
            return _newsLetter.ListAll(x => x.MailId == id);
        }

        public List<NewsLetter> ListAll(Expression<Func<NewsLetter, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(NewsLetter entity)
        {
            _newsLetter.Update(entity);
        }
    }
}
