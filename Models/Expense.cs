using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models
{
    public class Expense
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Cost { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
