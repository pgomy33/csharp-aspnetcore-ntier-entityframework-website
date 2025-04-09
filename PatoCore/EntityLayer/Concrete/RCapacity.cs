using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RCapacity
    {
        [Key]
        public int ID { get; set; }
        public string? Capacity { get; set; }
        public bool? State { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
