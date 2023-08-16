using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemSummaryVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Scientific_Name { get; set; }
        [Required]
        public string Drug_Type { get; set; }
    }
}
