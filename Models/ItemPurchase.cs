using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Parmacy.Shaar.Models
{
    [Table("items_Purchase")]
    public class ItemPurchase
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Receipt_No { get; set; }
        [Required]
        public DateTime Receipt_Date { get; set; }
        [Required]
        public int Item_ID { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public float Quantity_Per_Item { get; set; }
        [Required]
        public float Item_Bonus { get; set; }
        [Required]
        public DateTime Expiration_Date { get; set; }
        [AllowNull]
        public string Note { get; set; }

        [ForeignKey("Item_ID")]
        public Item Item { get; set; }
        [ForeignKey("Receipt_No")]
        public BuyInvoice Invoice { get; set; }
    }
}
