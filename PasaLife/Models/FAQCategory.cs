 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class FAQCategory
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }
        public bool IsDeactive { get; set; }
        public ICollection<FAQ> FAQs { get; set; }

    }
}
