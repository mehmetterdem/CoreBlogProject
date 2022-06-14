using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public Blog Get(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.ListAll();
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
