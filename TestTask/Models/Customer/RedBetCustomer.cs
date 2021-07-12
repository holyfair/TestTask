using System.ComponentModel.DataAnnotations;
using TestTask.Enums;

namespace TestTask.Models.Customer
{
    public class RedBetCustomer : CustomerBase
    {
        [Required]
        public string FavoriteFootballTeam { get; set; }
    }
}
