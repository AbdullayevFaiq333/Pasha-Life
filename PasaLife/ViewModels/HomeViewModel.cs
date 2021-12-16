using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewModels
{
    public class HomeViewModel
    {
        public HomeCenter Left { get; set; }
        public HomeCenter Right { get; set; }
        public HomeCenter Bottom { get; set; }
        public ICollection<HomeCarousel> HomeCarousels { get; set; }
    }
}
