using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemLocationVM
    {
        [Key]
        public int ItemID { get; set; }
        [DisplayName("Name")]
        public string Item_Name { get; set; }
        [DisplayName("Expiration Date")]
        public string Expiration_Date { get; set; }
        public string Quantity { get; set; }
        public string Location { get; set; }
    }
}
