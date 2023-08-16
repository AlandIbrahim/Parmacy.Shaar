using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemDetails
    {
        [Key]
        [DisplayName("ID")]
        public int Item_Id { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Scientific name")]
        public string Scientific_Name { get; set; }
        public string description { get; set; }
        [Required]
        [DisplayName("Manufacture location")]
        public string Manufacture_Location { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        [DisplayName("Drug type")]
        public string Drug_Type { get; set; }
        [DisplayName("Available batches")]
        public List<ItemInfo> AvailableBatches { get; set; }
    }
}
