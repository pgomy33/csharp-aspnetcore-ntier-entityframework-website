﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MenuCategory
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public bool? State { get; set; }
        public ICollection<Repeat3> MenuItems { get; set; }
    }
}
