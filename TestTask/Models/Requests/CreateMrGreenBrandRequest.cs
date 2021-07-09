using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TestTask.Models.Requests
{
    public class CreateMrGreenBrandRequest : CreateBrandBaseRequest
    {
        [Required]
        public string FavoriteFootballTeam { get; set; }
    }
}
