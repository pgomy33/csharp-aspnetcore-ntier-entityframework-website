using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ViewModels
{
    public class HourCapacityViewModel
    {
        public Reservation Reservation { get; set; }
        public List<RHours> Hours { get; set; }
        public List<RCapacity> Capacities { get; set; }
    }
}
