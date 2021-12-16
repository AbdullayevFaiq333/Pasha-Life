using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaLife.Models
{
    public class VacancyDetail
    {
        public int Id { get; set; }
        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }    

        

        public DateTime DateTime { get; set; }


        [ForeignKey("Vacancy")]
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
