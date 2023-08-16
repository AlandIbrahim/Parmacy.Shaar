using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string permission { get; set; }

        [Required]
        public float Salary { get; set; }
    }
}
