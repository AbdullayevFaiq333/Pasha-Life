using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class HomeCarousel
    { 
        public int Id { get; set; }
        public string Image { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }
   
        public string URL { get; set; }
        public DateTime DateTime { get; set; }

     

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
