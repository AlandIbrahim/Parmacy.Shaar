namespace Parmacy.Shaar.Models.ViewModels
{
    public class UserVM
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public float Salary { get; set; }
        public List<SellInvoice> Sales { get; set; }
    }
}
