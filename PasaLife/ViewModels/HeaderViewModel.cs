using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewModels
{
    public class HeaderViewModel
    {
        public List<Navbar> Navbars { get; set; }
        public IconButton IconButton { get; set; }
        public List<SecondMenu> SecondMenus { get; set; }
        public List<Product> Products { get; set; }
        public List<OnlineService> OnlineServices { get; set; }
        public List<InformationCenter> InformationCenters { get; set; }

    }
}
