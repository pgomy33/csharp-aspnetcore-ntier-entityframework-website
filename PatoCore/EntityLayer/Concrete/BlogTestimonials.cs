using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class BlogTestimonials
	{
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
		public int BlogId { get; set; }
		public Blog Blog { get; set; }

	}
}
