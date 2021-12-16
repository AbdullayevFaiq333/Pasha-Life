using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class Report
    {
        public int Id { get; set; }
        
        public int Year { get; set; }
        public string AzName { get; set; }
        public string RuName { get; set; }
        public string EnName { get; set; }


        
   
        public string FileName { get; set; }
        public string Size { get; set; }
        
        [NotMapped]
        public IFormFile File { get; set; }
        public int ReportCategoryId { get; set; }
        public ReportCategory ReportCategory { get; set; }
        public bool IsDeactive { get; set; }


    }
}
