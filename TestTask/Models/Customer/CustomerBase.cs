using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestTask.Enums;

namespace TestTask.Models.Customer
{
    public class CustomerBase
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public AddressModel Address { get; set; }

        [JsonIgnore]
        public BrandType BrandType { get; set; }
    }
}
