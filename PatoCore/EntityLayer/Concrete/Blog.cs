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
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? BlogImage { get; set; }
        public bool? State { get; set; }
        public DateTime DateTimeWrite { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory{ get; set; }
        public ICollection<BlogTestimonials> BlogTestimonials { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
