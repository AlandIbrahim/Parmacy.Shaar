using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    [Table("item_Sales")]
    public class ItemSale
    {
        [Key]
        public int Sale_Item_Id { get; set; }
        [Required]
        [Column(Order = 2)]
        public int Item_Id { get; set; }
        [Required]
        public int Invoice_No { get; set; }
        [Required]
        public float Item_Quantity { get; set; }
        [Required]
        public float Item_Discount { get; set; }
        [Required]
        [Column(Order = 1)]
        public DateTime Expiration_Date { get; set; }


        [ForeignKey("Expiration_Date,Item_Id")]
        public ItemInfo Item { get; set; }
        [ForeignKey("Invoice_No")]
        public SellInvoice Invoice { get; set; }
    }
}
