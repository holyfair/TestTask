using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private DbContext context;

        public CustomersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateCustomerAsync<T>(T model) where T : class
        {
            var set = this.context.Set<T>();
            var record = await set.AddAsync(model);

            return record.Entity;
        }
    }
}
