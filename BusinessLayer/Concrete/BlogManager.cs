using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void TAdd(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.ListAll();
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.ListAll(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.ListAll(x => x.WriterId == id);
        }
        public List<Blog> BlogLast3Post()
        {
            return _blogDal.ListAll().Take(3).ToList();
        }
        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

     
    }
}
