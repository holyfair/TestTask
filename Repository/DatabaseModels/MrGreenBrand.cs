using System;

namespace Repository.DatabaseModels
{
    public class MrGreenBrand
    {
        public Guid Id { get; set; }

        public string PersonalNumber { get; set; }

        public Brand BrandBaseInfo { get; set; }

        public Guid BrandBaseInfoId { get; set; }
    }
}
