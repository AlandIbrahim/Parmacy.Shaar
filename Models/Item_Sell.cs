using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parmacy.Shaar.Models
{
    public class Item_Sell
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Item_ID { get; set; }
        [Required]
        public float Sale_Price { get; set; }
        [Required]
        public float Purchase_Price { get; set; }
        [ForeignKey("Item_ID")]
        public Item Item { get; set; }

    }
}
