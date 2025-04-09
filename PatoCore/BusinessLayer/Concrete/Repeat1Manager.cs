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
    public class Repeat1Manager : IRepeat1Service
    {
        IRepeat1Dal _Repeat;

        public Repeat1Manager(IRepeat1Dal repeat)
        {
            _Repeat = repeat;
        }

        public void TAdd(Repeat1 t)
        {
            _Repeat.Insert(t);
        }

        public void TDelete(Repeat1 t)
        {
            _Repeat.Delete(t);
        }

        public Repeat1 TGetById(int id)
        {
            return _Repeat.GetByID(id);
        }

        public List<Repeat1> TGetlist()
        {
            return _Repeat.GetList();
        }

        public void TUpdate(Repeat1 t)
        {
            _Repeat.Update(t);
        }
    }
}
