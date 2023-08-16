using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Parmacy.Shaar.Models
{
    [Table("items_Info")]
    public class ItemInfo
    {
        [Key]
        [Column(Order = 1)]
        public DateTime Expiration_Date { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Item_Id { get; set; }
        [Required]
        public string batch_no { get; set; }
        [AllowNull]
        public float Price { get; set; }
        [DefaultValue(0)]
        public float Quantity_in_Pharmacy { get; set; }
        [DefaultValue(0)]
        public float Quantity_in_Storage { get; set; }
        [MinLength(3)][MaxLength(3)]
        public string? Location_in_Pharmacy { get; set; }
        [MinLength(5)][MaxLength(5)]
        public string? Location_in_Storage { get; set; }

        [ForeignKey("Item_Id")]
        public Item Item { get; set; }
    }
}
