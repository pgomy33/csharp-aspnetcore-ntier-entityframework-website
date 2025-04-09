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
    public class CategoryManger  :ICategoryService
    {
        ICategoryDal _CategoryDal;

        public CategoryManger(ICategoryDal categoryDal)
        {
            _CategoryDal = categoryDal;
        }

        public void TAdd(Category t)
        {
            _CategoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _CategoryDal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _CategoryDal.GetByID(id);
        }

        public List<Category> TGetlist()
        {
            return _CategoryDal.GetList();
        }

        public void TUpdate(Category t)
        {
            _CategoryDal.Update(t);
        }
    }
}
