using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    public class Delegate
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^(\d{14})$", ErrorMessage = "Invalid Phone Number.")]
        public string Tel { get; set; }
        public int Company_ID { get; set; }

        [ForeignKey("Company_ID")]
        public virtual Company Company { get; set; }
    }
}
