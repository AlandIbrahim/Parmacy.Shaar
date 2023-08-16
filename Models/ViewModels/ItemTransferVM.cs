using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class ItemTransferVM
    {
        public int ID { get; set; }
        [DisplayName("Expiration date")]
        public DateOnly ExpirationDate { get; set; }
        [DisplayName("Quantity in pharmacy")]
        public float QuantityInPharmacy { get; set; }
        [DisplayName("Quantity in storage")]
        public float QuantityInStorage { get; set; }
        [RegularExpression(@"^[A-Z]\d{2}$",ErrorMessage = "Pharmacy shelf addresses are comprised of 1 character followed by 2 numerical digits")]
        [StringLength(3,MinimumLength =3,  ErrorMessage = "Pharmacy shelf addresses are comprised of 1 character followed by 2 numerical digits")]
        [DisplayName("Location in pharmacy")]
        public string LocationInPharmacy { get; set; }
        [RegularExpression(@"^[A-Z]\d{4}$", ErrorMessage = "Storage unit addresses are comprised of 1 character followed by 4 numerical digits")]
        [StringLength(5,MinimumLength =5, ErrorMessage = "Storage unit addresses are comprised of 1 character followed by 4 numerical digits")]
        [DisplayName("Location in storage")]
        public string LocationInStorage { get; set; }
    }
}
