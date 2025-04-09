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
    public class GalleryManager : IGalleryService
    {
        IGalleryDal _Gallery;

        public GalleryManager(IGalleryDal gallery)
        {
            _Gallery = gallery;
        }

        public void TAdd(Gallery t)
        {
            _Gallery.Insert(t);
        }

        public void TDelete(Gallery t)
        {
            _Gallery.Delete(t);
        }

        public Gallery TGetById(int id)
        {
            return _Gallery.GetByID(id);
        }

        public List<Gallery> TGetlist()
        {
            return _Gallery.GetList();
        }

        public void TUpdate(Gallery t)
        {
            _Gallery.Update(t); 
        }
    }
}
