using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class About
    {
        public int Id { get; set; }
        
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

        public bool IsDeactive { get; set; }


    }
}
