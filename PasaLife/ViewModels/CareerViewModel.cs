using PasaLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.ViewModels
{
    public class CareerViewModel
    {
        public Career Career { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }

    }
}
