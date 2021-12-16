using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewModels
{
    public class InformationVM
    {
        public List<FAQCategory> FAQCategories { get; set; }
        public List<New> News { get; set; }
        public List<RuleCategory> RuleCategories { get; set; }
        public string Type { get; set; }
    }
}
