using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    [Table("buy_Invoices")]
    public class BuyInvoice
    {
        [Key]
        public int No { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Employee_Id { get; set; }
        [Required]
        public int Delegate_Id { get; set; }
        [ForeignKey("Delegate_Id")]
        public Delegate Delegate { get; set; }
        [ForeignKey("Employee_Id")]
        public User Employee { get; set; }
    }
}
