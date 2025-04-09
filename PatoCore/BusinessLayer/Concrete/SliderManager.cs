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
    public class SliderManager : ISliderService
    {
        ISliderDal _SliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _SliderDal = sliderDal;
        }

        public void TAdd(Slider t)
        {
            _SliderDal.Insert(t);
        }

        public void TDelete(Slider t)
        {
            _SliderDal.Delete(t);   
        }

        public Slider TGetById(int id)
        {
            return _SliderDal.GetByID(id);
        }

        public List<Slider> TGetlist()
        {
            return _SliderDal.GetList();
        }

        public void TUpdate(Slider t)
        {
            _SliderDal.Update(t);
        }
    }
}
