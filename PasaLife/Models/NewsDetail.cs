using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class NewsDetail
    {
        public int Id { get; set; }
        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }

        public string AzSeoDescription { get; set; }
        public string RuSeoDescription { get; set; }
        public string EnSeoDescription { get; set; }

        [ForeignKey("New")]
        public int NewId { get; set; }
        public New New { get; set; }
    }
}
