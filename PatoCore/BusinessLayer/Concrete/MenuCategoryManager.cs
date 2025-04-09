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
    public class MenuCategoryManager : IMenuCategoryService
    {
        IMenuCategoryDal _dal;

        public MenuCategoryManager(IMenuCategoryDal dal)
        {
            _dal = dal;
        }

        public void TAdd(MenuCategory t)
        {
            _dal.Insert(t);
        }

        public void TDelete(MenuCategory t)
        {
            _dal.Delete(t);
        }

        public MenuCategory TGetById(int id)
        {
            return _dal.GetByID(id);
        }

        public List<MenuCategory> TGetlist()
        {
            return _dal.GetList();
        }

        public void TUpdate(MenuCategory t)
        {
            _dal.Update(t); 
        }
    }
}
