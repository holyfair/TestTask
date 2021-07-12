using System.ComponentModel.DataAnnotations;

namespace TestTask.Models.Customer
{
    public class AddressModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public int House { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }
    }
}
