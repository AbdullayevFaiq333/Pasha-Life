namespace PasaLife.Models
{
    public class ManagementFaq
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string RuTitle { get; set; }
        public string EnTitle { get; set; }
        public string AzDescription { get; set; }
        public string RuDescription { get; set; }
        public string EnDescription { get; set; }
        public bool IsDeactive { get; set; }
        public int ManagementCategoryId { get; set; }
        public ManagementCategory ManagementCategory { get; set; }
    }
}
