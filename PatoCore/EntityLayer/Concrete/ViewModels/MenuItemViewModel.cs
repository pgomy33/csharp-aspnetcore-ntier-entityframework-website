using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ViewModels
{
    public class MenuItemViewModel
    {
        public Repeat3 menuItem { get; set; }
        public List<Repeat3> MenuList { get; set; }
        public List<MenuCategory> Categories { get; set; }
    }
}
