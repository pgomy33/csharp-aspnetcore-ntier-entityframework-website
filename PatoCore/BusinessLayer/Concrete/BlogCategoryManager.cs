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
    public class BlogCategoryManager : IBlogCategoryService
    {
        IBlogCategoryDal _dal;

        public BlogCategoryManager(IBlogCategoryDal dal)
        {
            _dal = dal;
        }

        public void TAdd(BlogCategory t)
        {
            _dal.Insert(t);
        }

        public void TDelete(BlogCategory t)
        {
            _dal.Delete(t);
        }

        public BlogCategory TGetById(int id)
        {
            return _dal.GetByID(id);
        }

        public List<BlogCategory> TGetlist()
        {
            return _dal.GetList();
        }

        public void TUpdate(BlogCategory t)
        {
            _dal.Update(t);
        }
    }
}
