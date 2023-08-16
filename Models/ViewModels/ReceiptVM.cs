using System.ComponentModel;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ReceiptVM
    {
        public DateTime Date { get; set; }
        public string Employee { get; set; }
        public string Delegate { get; set; }
        public List<ItemPriceVM> Items { get; set; }
    }
}
