using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class CommentManager : IGenericService<Comment>
    {




        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment Get(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> ListAll(int id)
        {
            return _commentDal.ListAll(x => x.BlogId == id);
        }

        public List<Comment> ListAll(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}