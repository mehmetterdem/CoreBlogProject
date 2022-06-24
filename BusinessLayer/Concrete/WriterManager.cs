using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.ListAll(x => x.WriterId == id);
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
