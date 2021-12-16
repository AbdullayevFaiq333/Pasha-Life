using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Models
{
    public class RuleCategory 
    {
        public int Id { get; set; }
        public string AzName { get; set; }
        public string RuName { get; set; }
        public string EnName { get; set; }
        public bool IsDeactive { get; set; }

        public ICollection<Rule> Rules { get; set; }
    }
}
