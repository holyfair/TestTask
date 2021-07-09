using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class CreateAddressModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public int House { get; set; }

        [Required]
        public int ZipCode { get; set; }
    }
}
