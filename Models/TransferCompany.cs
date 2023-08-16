using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    [Table("transfer_Companies")]
    public class TransferCompany
    {
        [Key]
        public int ID { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public int Delegate_ID { get; set; }
        [ForeignKey("Delegate_ID")]
        public Delegate Delegate { get; set; }
    }
}
