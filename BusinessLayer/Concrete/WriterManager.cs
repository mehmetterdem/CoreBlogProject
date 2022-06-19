﻿using BusinessLayer.Abstract;
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

        public void Add(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void Delete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        //public List<Writer> ListAll(int id)
        //{
        //    return _writerDal.ListAll();
        //}



        public List<Writer> GetList()
        {
            return _writerDal.ListAll();
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
