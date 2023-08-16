using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    [Table("sell_Invoices")]
    public class SellInvoice
    {
        [Key]
        public int No { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Employee_Id { get; set; }
        [Required]
        public int Cu_Id { get; set; }
        [ForeignKey("Cu_Id")]
        public Customer Customer { get; set; }
        [ForeignKey("Employee_Id")]
        public User User { get; set; }
    }
}
