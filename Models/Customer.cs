using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"^(\d{14})$", ErrorMessage = "Invalid Phone Number.")]
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}
