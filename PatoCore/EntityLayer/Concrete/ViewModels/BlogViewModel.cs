using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ViewModels
{
    public class BlogViewModel
    {
        public Blog  Blog{ get; set; }
        public BlogTestimonials  BlogTestimonial{ get; set; }
        public List<Blog> Blogs { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }
        public List<BlogTestimonials> BlogTestimonials { get; set; }
    }
}
