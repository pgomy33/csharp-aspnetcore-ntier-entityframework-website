using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Slider
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SliderImage { get; set; }
        public bool? State { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
