using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class Management
    {
        public int Id { get; set; }
        public string AzFullName { get; set; }
        public string RuFullName { get; set; }
        public string EnFullName { get; set; }

        public string AzPosition { get; set; }
        public string RuPosition { get; set; }
        public string EnPosition { get; set; }

        public string AzSeoTitle { get; set; }
        public string RuSeoTitle { get; set; }
        public string EnSeoTitle { get; set; }

       
        public string Image { get; set; }
        public bool IsDeactive { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public int ManagementCategoryId { get; set; }
        public ManagementCategory ManagementCategory{ get; set; }
        public ManagementDetail ManagementDetail { get; set; }
    }
}
