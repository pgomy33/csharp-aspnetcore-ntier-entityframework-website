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
    public class SSSManager : ISSSService
    {
        ISSSDal _SSS;

        public SSSManager(ISSSDal sSS)
        {
            _SSS = sSS;
        }

        public void TAdd(SSS t)
        {
            _SSS.Insert(t);
        }

        public void TDelete(SSS t)
        {
            _SSS.Delete(t);
        }

        public SSS TGetById(int id)
        {
            return _SSS.GetByID(id);
        }

        public List<SSS> TGetlist()
        {
            return _SSS.GetList();
        }

        public void TUpdate(SSS t)
        {
            _SSS.Update(t);
        }
    }
}
