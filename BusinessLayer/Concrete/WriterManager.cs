using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TAdd(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void TDelete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        //public List<Writer> ListAll(int id)
        //{
        //    return _writerDal.ListAll();
        //}



        public List<Writer> TGetList()
        {
            return _writerDal.ListAll();
        }

        public void TUpdate(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
