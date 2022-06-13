using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Update(Blog entity)
        {
             _blogDal.Update(entity);
        }
    }
}
