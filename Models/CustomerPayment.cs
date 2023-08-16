using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    [Table("customer_Payments")]
    public class CustomerPayment
    {
        [Key]
        public int ID { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public int Invoice_No { get; set; }
        public int Cu_Id { get; set; }

        [ForeignKey("Cu_Id")]
        public Customer Customer { get; set; }
    }
}
