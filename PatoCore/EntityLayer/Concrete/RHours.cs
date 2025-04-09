using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RHours
    {
        [Key]
        public int ID { get; set; }
        public string? Hour { get; set; }
        public bool? State { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
