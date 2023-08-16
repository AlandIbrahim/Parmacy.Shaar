using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemSaleVM
    {
        [Key]
        public int Sale_Item_Id { get; set; }
        [Required]
        [Column(Order = 2)]
        [DisplayName("Item")]
        public int Item_Id { get; set; }
        [Required]
        [DisplayName("Receipt number")]
        public int Invoice_No { get; set; }
        [DisplayName("Customer")]
        public int Cu_Id { get; set; }
        [Required]
        [DisplayName("Quantity")]
        public float Item_Quantity { get; set; }
        [Required]
        [DisplayName("Price")]
        public float Item_Price { get; set; }
        [Required]
        [DisplayName("Discount")]
        public float Item_Discount { get; set; }
        [Required]
        [Column(Order = 1)]
        [DisplayName("Expiration date")]
        public DateTime Expiration_Date { get; set; }


        [ForeignKey("Expiration_Date,Item_Id")]
        [ValidateNever]
        public ItemInfo Item { get; set; }
    }
}
