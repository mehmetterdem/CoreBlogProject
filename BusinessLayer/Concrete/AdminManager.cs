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
    public class AdminManager : IAdminService
    {
        IAdminDal _AdminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _AdminDal = adminDal;
        }

        public void TAdd(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
