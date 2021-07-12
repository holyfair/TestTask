using System;

namespace Repository.DatabaseModels
{
    public class MrGreenCustomer
    {
        public Guid Id { get; set; }

        public string PersonalNumber { get; set; }

        public BaseCustomer BaseCustomerInfo { get; set; }

        public Guid BaseCustomerInfoId { get; set; }
    }
}
