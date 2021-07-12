using System;

namespace Repository.DatabaseModels
{
    public class RedBetCustomer
    {
        public Guid Id { get; set; }

        public string FavoriteFootballTeam { get; set; }

        public BaseCustomer BaseCustomerInfo { get; set; }

        public Guid BaseCustomerInfoId { get; set; }
    }
}
