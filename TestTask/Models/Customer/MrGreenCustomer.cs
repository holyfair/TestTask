using System.ComponentModel.DataAnnotations;

namespace TestTask.Models.Customer
{
    public class MrGreenCustomer : CustomerBase
    {
        [RegularExpression(@"[0-9]{5}-[0-9]{3}$", ErrorMessage = "Invalid phone number")]
        [Required] 
        public string PersonalNumber { get; set; }
    }
}
