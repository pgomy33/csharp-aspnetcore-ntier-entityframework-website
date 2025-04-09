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
    public class IRCapacityManager : IRCapacityService
    {
        IRCapacityDal _dal;

        public IRCapacityManager(IRCapacityDal dal)
        {
            _dal = dal;
        }

        public void TAdd(RCapacity t)
        {
            _dal.Insert(t);
        }

        public void TDelete(RCapacity t)
        {
            _dal.Delete(t);
        }

        public RCapacity TGetById(int id)
        {
            return _dal.GetByID(id);
        }

        public List<RCapacity> TGetlist()
        {
            return _dal.GetList();
        }

        public void TUpdate(RCapacity t)
        {
            _dal.Update(t);
        }
    }
}
