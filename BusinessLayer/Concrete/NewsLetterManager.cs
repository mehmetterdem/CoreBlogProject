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

        public NewsLetter GetById(int id)
        {
            return _newsLetter.GetById(id);
        }

        //public List<NewsLetter> GetList(int id)
        //{
        //    return _newsLetter.ListAll(x => x.MailId == id);
        //}

        
        public List<NewsLetter> GetList()
        {
            return _newsLetter.ListAll();
        }

        public void Update(NewsLetter entity)
        {
            _newsLetter.Update(entity);
        }
    }
}
