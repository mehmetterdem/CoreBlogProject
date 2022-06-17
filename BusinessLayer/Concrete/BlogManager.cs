using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
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

        public List<Blog> ListAll()
        {
            return _blogDal.ListAll();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.ListAll(x => x.BlogId == id);
        }

        public List<Blog> ListAll(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> ListAll(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogDal.ListAll(x => x.WriterId == id);
        }
    }
}
