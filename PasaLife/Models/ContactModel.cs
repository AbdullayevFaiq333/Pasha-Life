using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }
        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }
        public string AzAddress { get; set; }
        public string RuAddress { get; set; }
        public string EnAddress { get; set; }

        public string ContactNumber { get; set; }
        public ContactMessage ContactMessage { get; set; }
    }
}
