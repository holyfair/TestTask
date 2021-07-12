using System.ComponentModel.DataAnnotations;

namespace TestTask.Models.Customer
{
    public class RedBetCustomer : CustomerBase
    {
        [Required]
        public string FavoriteFootballTeam { get; set; }
    }
}
