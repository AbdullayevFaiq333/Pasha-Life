using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ReportCategory
    {
        public int Id { get; set; }
        public string AzName { get; set; }
        public string RuName { get; set; }
        public string EnName { get; set; }
        public bool IsDeactive { get; set; }

        public ICollection<Report> Reports { get; set; }
         
         

    }
}
