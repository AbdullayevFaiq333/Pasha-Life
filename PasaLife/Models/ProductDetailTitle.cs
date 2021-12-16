using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ProductDetailTitle
    {
        public int Id { get; set; }
        public string AzFirstSection { get; set; }
        public string RuFirstSection { get; set; }
        public string EnFirstSection { get; set; }
        public string AzSecondSection { get; set; }
        public string RuSecondSection { get; set; }
        public string EnSecondSection { get; set; }
        public string AzThirdSection { get; set; }
        public string RuThirdSection { get; set; }
        public string EnThirdSection { get; set; }
        public string AzFourthSection { get; set; }
        public string RuFourthSection { get; set; }
        public string EnFourthSection { get; set; }

        public bool IsDeactive { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
