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
    public class Repeat2Manager : IRepeat2Service
    {
        IRepeat2Dal _Repeat;

        public Repeat2Manager(IRepeat2Dal repeat)
        {
            _Repeat = repeat;
        }

        public void TAdd(Repeat2 t)
        {
            _Repeat.Insert(t);
        }

        public void TDelete(Repeat2 t)
        {
            _Repeat.Delete(t);
        }

        public Repeat2 TGetById(int id)
        {
            return _Repeat.GetByID(id);
        }

        public List<Repeat2> TGetlist()
        {
            return _Repeat.GetList();
        }

        public void TUpdate(Repeat2 t)
        {
            _Repeat.Update(t);
        }
    }
}
