using System;

namespace Repository.DatabaseModels
{
    public class BaseCustomer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public int House { get; set; }

        public int ZipCode { get; set; }
    }
}
