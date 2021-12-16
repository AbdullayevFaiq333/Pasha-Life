using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }

        public string Icon { get; set; }
        public string Url { get; set; }

        public bool IsDeactive { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
