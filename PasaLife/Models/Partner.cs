using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsDeactive { get; set; }
        public Product Product { get; set; }
        public int? ProductId { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
