using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Repository.Database;
using Repository.Models.Customer;

namespace Repository.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IMongoCollection<CustomerModel> customers;

        public CustomersRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            customers = database.GetCollection<CustomerModel>("Customers");
        }

        public async Task<CustomerModel> CreateAsync(CustomerModel customer)
        {
            await customers.InsertOneAsync(customer);
            return customer;
        }

        public async Task<IEnumerable<object>> GetAsync()
        {
            return await this.customers.Find(_ => true).ToListAsync();
        }
    }
}
