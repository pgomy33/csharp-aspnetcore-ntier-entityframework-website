using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogCategory
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
         public bool? State { get; set; }
        public ICollection<Blog> Blog { get; set; }
    }
}
