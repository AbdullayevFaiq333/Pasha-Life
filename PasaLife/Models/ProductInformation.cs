using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ProductInformation
    {
        public int Id { get; set; }

        public string AzSectionTitle { get; set; }
        public string RuSectionTitle { get; set; }
        public string EnSectionTitle { get; set; }

        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }
      
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public bool IsDeactive { get; set; }
    }
}
