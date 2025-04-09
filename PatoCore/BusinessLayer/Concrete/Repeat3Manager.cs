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
    public class Repeat3Manager : IRepeat3Service
    {
        IRepeat3Dal _Repeat;

        public Repeat3Manager(IRepeat3Dal repeat)
        {
            _Repeat = repeat;
        }

        public void TAdd(Repeat3 t)
        {
            _Repeat.Insert(t);
        }

        public void TDelete(Repeat3 t)
        {
            _Repeat.Delete(t);  
        }

        public Repeat3 TGetById(int id)
        {
            return _Repeat.GetByID(id);
        }

        public List<Repeat3> TGetlist()
        {
            return _Repeat.GetList();
        }

        public void TUpdate(Repeat3 t)
        {
            _Repeat.Update(t);  
        }
    }
}
