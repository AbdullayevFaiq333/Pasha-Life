using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaLife.Models
{
    public class ProductItem1
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; } 
        public string EnTitle { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }

        public string AzDescriptionBox { get; set; } 
        public string RuDescriptionBox { get; set; }
        public string EnDescriptionBox { get; set; }

        public string AzInfo { get; set; }
        public string RuInfo { get; set; }
        public string EnInfo { get; set; }

        public string Image { get; set; }
        
        public string Name { get; set; }
        public string AzWork { get; set; }
        public string RuWork { get; set; }
        public string EnWork { get; set; }
        public string AzEndDescription { get; set; }
        public string RuEndDescription { get; set; }
        public string EnEndDescription { get; set; }
        

        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
