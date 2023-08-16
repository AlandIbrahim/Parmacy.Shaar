using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemNameVM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
