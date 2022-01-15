using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaLife.Models
{
    public class ProductItem2
    {
        public int Id { get; set; } 
        public string AzTitle { get; set; } 
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }


        public string AzTitleBox { get; set; }
        public string RuTitleBox { get; set; }
        public string EnTitleBox { get; set; }

        public string FirstBoxIcon { get; set; }
        public string AzFirstBoxInfo { get; set; }
        public string RuFirstBoxInfo { get; set; }
        public string EnFirstBoxInfo { get; set; }

        public string SecondBoxIcon { get; set; }
        public string AzSecondBoxInfo { get; set; }
        public string RuSecondBoxInfo { get; set; }
        public string EnSecondBoxInfo { get; set; }

        public string Image { get; set; }
        public string AzImageTitle { get; set; }
        public string RuImageTitle { get; set; }
        public string EnImageTitle { get; set; }

        public string AzCondition { get; set; }
        public string RuCondition { get; set; }
        public string EnCondition { get; set; }

        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [NotMapped]

        public IFormFile FirstBoxPhoto { get; set; }
        [NotMapped]

        public IFormFile SecondBoxPhoto { get; set; }
    }
}
