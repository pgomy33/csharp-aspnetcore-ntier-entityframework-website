using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Email adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string? Mail { get; set; }
        public DateTime Date { get; set; }
        public bool? State { get; set; }

        [ForeignKey("rHours")]
        public int rHoursID { get; set; }
        public RHours rHours { get; set; }

        [ForeignKey("rCapacity")]
        public int rCapacityID { get; set; }
        public RCapacity rCapacity { get; set; }
    }
}
