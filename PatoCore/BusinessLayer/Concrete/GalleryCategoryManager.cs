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
    public class GalleryCategoryManager : IGalleryCateogryService
    {
        IGalleryCategoryDal _Dal;

        public GalleryCategoryManager(IGalleryCategoryDal dal)
        {
            _Dal = dal;
        }

        public void TAdd(GalleryCategory t)
        {
            _Dal.Insert(t);
        }

        public void TDelete(GalleryCategory t)
        {
            _Dal.Delete(t);
        }

        public GalleryCategory TGetById(int id)
        {
            return _Dal.GetByID(id);
        }

        public List<GalleryCategory> TGetlist()
        {
            return _Dal.GetList();
        }

        public void TUpdate(GalleryCategory t)
        {
            _Dal.Update(t);
        }
    }
}
