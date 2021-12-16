using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class HomeCarouselSeo
    {
        public int Id { get; set; }
        public string AzSeoTitle { get; set; }
        public string RuSeoTitle { get; set; }
        public string EnSeoTitle { get; set; }

    }

}
