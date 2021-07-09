using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using TestTask.Enums;

namespace TestTask.Models
{
    public abstract class CreateBrandBaseRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public CreateAddressModel Address { get; set; }

        [Required]
        public BrandType BrandType { get; set; }
    }
}
