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

        public void TAdd(NewsLetter entity)
        {
            _newsLetter.Add(entity);
        }

        public void TDelete(NewsLetter entity)
        {
            _newsLetter?.Delete(entity);
        }

        public NewsLetter TGetById(int id)
        {
            return _newsLetter.GetById(id);
        }

        //public List<NewsLetter> GetList(int id)
        //{
        //    return _newsLetter.ListAll(x => x.MailId == id);
        //}

        
        public List<NewsLetter> TGetList()
        {
            return _newsLetter.ListAll();
        }

        public void TUpdate(NewsLetter entity)
        {
            _newsLetter.Update(entity);
        }
    }
}
