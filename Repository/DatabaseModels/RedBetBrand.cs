using System;

namespace Repository.DatabaseModels
{
    public class RedBetBrand
    {
        public Guid Id { get; set; }

        public string FavoriteFootballTeam { get; set; }

        public Brand BrandBaseInfo { get; set; }

        public Guid BrandBaseInfoId { get; set; }
    }
}
