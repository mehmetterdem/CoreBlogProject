using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact Get(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> ListAll(int id)
        {
            return _contactDal.ListAll();
        }

        public List<Contact> ListAll(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Contact> ListAll()
        {
            return _contactDal.ListAll();
        }

        public void Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
