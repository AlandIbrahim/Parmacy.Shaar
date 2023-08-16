using System.ComponentModel.DataAnnotations;

namespace Parmacy.Shaar.Models.ViewModels
{
    public class LoginVM
    {
        [Key]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
