using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^(\d{14})$", ErrorMessage = "Invalid Phone Number.")]
        public string Tel { get; set; }
    }
}
