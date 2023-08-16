using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class Item_SaleVM
    {

        [Key]
        public int Sale_Item_Id { get; set; }
        [Required]
        [DisplayName("Item")]
        public int Item_Id { get; set; }
        [Required]
        public int Cu_Id { get; set; }
        [Required]
        public int Invoice_No { get; set; }
        [Required]
        public float Item_Quantity { get; set; }
        [Required]
        [DisplayName("Price")]
        public float Item_Price { get; set; }
        [Required]
        [DisplayName("Discount")]
        public float Item_Discount { get; set; }
        [ForeignKey("Item_Id")]
        public Item Item { get; set; }
        [ForeignKey("Cu_Id")]
        public Customer Customer { get; set; }
        [ForeignKey("Invoice_No")]
        public SellInvoice Invoice { get; set; }
    }
}
