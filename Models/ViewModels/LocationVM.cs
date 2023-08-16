using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class LocationVM
    {
        [Key]
        public string Location { get; set; }
        public List<ItemNameVM> Items { get; set; }
    }
}
