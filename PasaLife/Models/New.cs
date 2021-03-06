using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class New
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }

        public string AzSeoTitle { get; set; }
        public string RuSeoTitle { get; set; }
        public string EnSeoTitle { get; set; }

       
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeactive { get; set; }

        public NewsDetail NewsDetail { get; set; }

        public InformationCenter InformationCenter { get; set; }
        [ForeignKey("InformationCenter")]
        public int? InformationCenterId { get; set; }

    }
}
