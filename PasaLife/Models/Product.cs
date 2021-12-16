using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string AzTitle { get; set; } 
        public string RuTitle { get; set; } 
        public string EnTitle { get; set; }

        public string AzTitle2 { get; set; }
        public string RuTitle2 { get; set; }
        public string EnTitle2 { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }

        public string AzDetailDescription { get; set; }
        public string RuDetailDescription { get; set; }
        public string EnDetailDescription { get; set; }

        public string AzSeoTitle { get; set; }
        public string RuSeoTitle { get; set; }
        public string EnSeoTitle { get; set; }

        public string AzSeoDescription { get; set; }
        public string RuSeoDescription { get; set; }
        public string EnSeoDescription { get; set; }



        public string VideoUrl { get; set; }
       
        public string Video { get; set; }
        public bool IsDeactive { get; set; }
        public bool IsSimple { get; set; }


        public List<ProductChart> ProductCharts { get; set; }
        public List<Customer> Customers { get; set; }
        public List<FAQ> FAQs { get; set; }
        public List<Partner> Partners { get; set; }
        public SimpleProduct SimpleProduct { get; set; }
        public ProductInformation ProductInformation { get; set; }
        public ProductDetailTitle ProductDetailTitle { get; set; }
        public List<ProductWord> ProductWords { get; set; }

        [NotMapped]
        public IFormFile VideoFile { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
