using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class InvoiceVM
    {
        [Key]
        public int No { get; set; }
        [Required]
        public int Cu_Id { get; set; }
        [ForeignKey("Cu_Id")]
        public Customer Customer { get; set; }
        public List<ItemSaleVM> Items { get; set; }
    }
}
