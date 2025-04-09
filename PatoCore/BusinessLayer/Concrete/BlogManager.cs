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
    public class BlogManager : IBlogService
    {
        IBlogDal _BlogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _BlogDal = blogDal;
        }

        public void TAdd(Blog t)
        {
            _BlogDal.Insert(t);       
        }

        public void TDelete(Blog t)
        {
            _BlogDal.Delete(t); 
        }

        public Blog TGetById(int id)
        {
            return _BlogDal.GetByID(id);
        }

        public List<Blog> TGetlist()
        {
            return _BlogDal.GetList();
        }

        public void TUpdate(Blog t)
        {
            _BlogDal.Update(t);
        }
    }
}
