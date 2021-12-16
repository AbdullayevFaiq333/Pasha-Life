using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewModels
{
    public class ReportViewModel
    {
        public List<Report> Reports { get; set; }
        public List<ReportCategory> ReportCategories { get; set; }

    }
}
