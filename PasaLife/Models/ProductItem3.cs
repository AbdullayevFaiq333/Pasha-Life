using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaLife.Models
{ 
    public class ProductItem3
    { 
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }

        public string AzDescription2 { get; set; }
        public string RuDescription2 { get; set; }
        public string EnDescription2 { get; set; }

        public string Image { get; set; }

        public string AzInfo { get; set; }
        public string RuInfo { get; set; }
        public string EnInfo { get; set; }

        public string AzSecondTitle { get; set; }
        public string RuSecondTitle { get; set; }
        public string EnSecondTitle { get; set; }

        public string AzSecondDescription { get; set; }
        public string RuSecondDescription { get; set; }
        public string EnSecondDescription { get; set; }

        public string AzThirdTitle { get; set; }
        public string RuThirdTitle { get; set; }
        public string EnThirdTitle { get; set; }

        public string AzThirdDescription { get; set; }
        public string RuThirdDescription { get; set; }
        public string EnThirdDescription { get; set; }

        

        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
