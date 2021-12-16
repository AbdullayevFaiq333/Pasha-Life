using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ProductWord
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        
        public bool IsDeactive { get; set; }
        public Product Product { get; set; }
       

        public int ProductId { get; set; }

    }
}
