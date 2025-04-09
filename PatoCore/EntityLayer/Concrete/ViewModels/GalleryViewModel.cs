using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EntityLayer.Concrete.ViewModels
{
    public class GalleryViewModel
    {
        public Gallery Gallery { get; set; }
        public List<GalleryCategory> Categories { get; set; }
        public List<Gallery> Galleries { get; set; }
    }
}
