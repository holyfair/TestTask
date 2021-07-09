using System.ComponentModel.DataAnnotations;
using TestTask.Enums;

namespace TestTask.Models
{
    public class CreateRedBetBrandRequest : CreateBrandBaseRequest
    {
        public BrandType BrandType => BrandType.RedBet;

        [Required]
        public string FavoriteFootballTeam { get; set; }
    }
}
