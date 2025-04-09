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
    public class ContactManager : IContactService
    {
        IContactDal _contact;

        public ContactManager(IContactDal contact)
        {
            _contact = contact;
        }

        public void TAdd(Contact t)
        {
            _contact.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contact.Delete(t);
        }

        public Contact TGetById(int id)
        {
            return _contact.GetByID(id);
        }

        public List<Contact> TGetlist()
        {
            return _contact.GetList();
        }

        public void TUpdate(Contact t)
        {
            _contact.Update(t);
        }
    }
}
