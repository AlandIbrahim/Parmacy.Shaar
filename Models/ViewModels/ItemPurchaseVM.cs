using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemPurchaseVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Item")]
        public int Item_ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Expiration date")]
        public DateTime Expiration_Date { get; set; }
        [Required]
        [DisplayName("Receipt number")]
        public int Receipt_No { get; set; }
        [Required]
        [DisplayName("Batch number")]
        public string Batch_Number { get; set; }
        [Required]
        [RegularExpression(@"[0-9]+(\.[0-9]{2})?")]
        public float Price { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        [DisplayName("Quantity per item")]
        public float Quantity_Per_Item { get; set; }
        [DisplayName("Bonus")]
        public float Item_Bonus { get; set; }
        [DisplayName("Delegate")]
        public int Delegate_ID { get; set; }
        public string Note { get; set; }

        [ForeignKey("Delegate_ID")]
        [ValidateNever]
        public Delegate Delegate { get; set; }
        [ForeignKey("Item_ID")]
        [ValidateNever]
        public Item Item { get; set; }
    }
}
