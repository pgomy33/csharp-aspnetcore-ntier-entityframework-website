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
    public class UserManager : IUserService
    {
        IUserDal _User;

        public UserManager(IUserDal user)
        {
            _User = user;
        }

        public void TAdd(User t)
        {
            _User.Insert(t);
        }

        public void TDelete(User t)
        {
            _User.Delete(t);
        }

        public User TGetById(int id)
        {
            return _User.GetByID(id);
        }

        public List<User> TGetlist()
        {
            return _User.GetList();
        }

        public void TUpdate(User t)
        {
            _User.Update(t);
        }
    }
}
