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
    public class ReservationManager : IReservationService
    {
        IReservationDal _dal;

        public ReservationManager(IReservationDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Reservation t)
        {
            _dal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _dal.Delete(t);
        }

        public Reservation TGetById(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Reservation> TGetlist()
        {
            return _dal.GetList();
        }

        public void TUpdate(Reservation t)
        {
            _dal.Update(t);
        }
    }
}
