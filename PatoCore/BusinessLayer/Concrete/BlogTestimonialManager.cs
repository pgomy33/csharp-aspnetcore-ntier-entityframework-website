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
	public class BlogTestimonialManager : IBlogTestimonialService
	{
		IBlogTestimonialDal _dal;

		public BlogTestimonialManager(IBlogTestimonialDal dal)
		{
			_dal = dal;
		}

		public void TAdd(BlogTestimonials t)
		{
			_dal.Insert(t);
		}

		public void TDelete(BlogTestimonials t)
		{
			_dal.Delete(t);
		}

		public BlogTestimonials TGetById(int id)
		{
			return _dal.GetByID(id);
		}

		public List<BlogTestimonials> TGetlist()
		{
			return _dal.GetList();
		}

		public void TUpdate(BlogTestimonials t)
		{
			_dal.Update(t);
		}
	}
}
