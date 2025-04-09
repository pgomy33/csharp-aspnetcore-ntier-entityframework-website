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
    public class RhoursManager : IRHoursService
    {
        IRHoursDal _dal;

        public RhoursManager(IRHoursDal dal)
        {
            _dal = dal;
        }

        public void TAdd(RHours t)
        {
            _dal.Insert(t);
        }

        public void TDelete(RHours t)
        {
            _dal.Delete(t);
        }

        public RHours TGetById(int id)
        {
            return _dal.GetByID(id);
        }

        public List<RHours> TGetlist()
        {
            return _dal.GetList();
        }

        public void TUpdate(RHours t)
        {
            _dal.Update(t);
        }
    }
}
