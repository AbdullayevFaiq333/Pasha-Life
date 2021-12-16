using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class Rule
    {
        public int Id { get; set; }
        
        public string AzName { get; set; }
        public string RuName { get; set; }
        public string EnName { get; set; }


       

  
        public string FileName { get; set; }
        public string Size { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
        public int RuleCategoryId { get; set; }
        public RuleCategory RuleCategory { get; set; }
        public bool IsDeactive { get; set; }
        public InformationCenter InformationCenter { get; set; }
        [ForeignKey("InformationCenter")]
        public int? InformationCenterId { get; set; }
    }
}
