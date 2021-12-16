using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ITPlatform
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }      

        public OnlineService OnlineService { get; set; }
        public int OnlineServiceId { get; set; }
        public string URL { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeactive { get; set; }

    }
}
