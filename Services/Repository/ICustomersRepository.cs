using Repository.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface ICustomersRepository
    {
        Task<CustomerModel> CreateAsync(CustomerModel customer);

        Task<IEnumerable<CustomerModel>> GetAsync();
    }
}
