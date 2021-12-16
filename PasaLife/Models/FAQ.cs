using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }
        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }
        public bool IsDeactive { get; set; }
        
        public int FAQCategoryId { get; set; }
        public FAQCategory FAQCategory { get; set; }

        public Product Product { get; set; }
        [ForeignKey("Product")]

        public int? ProductId { get; set; }

        public InformationCenter InformationCenter { get; set; }
    
        public int? InformationCenterId { get; set; }
    }
}
