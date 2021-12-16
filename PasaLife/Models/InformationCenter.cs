using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class InformationCenter
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string AzTitle { get; set; } 
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }


        public string AzSeoTitle { get; set; }
        public string RuSeoTitle { get; set; }
        public string EnSeoTitle { get; set; }

        public string AzSeoDescription { get; set; }
        public string RuSeoDescription { get; set; }
        public string EnSeoDescription { get; set; }

        public string URL { get; set; }
        public string Type { get; set; }
        public bool IsDeactive { get; set; } 
        public List<FAQ> FAQs { get; set; }
        public List<Rule> Rules { get; set; }
        public List<New> News { get; set; }


        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
