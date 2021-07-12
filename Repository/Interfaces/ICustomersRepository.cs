using Repository.DatabaseModels;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICustomersRepository
    {
        Task<T> CreateCustomerAsync<T>(T model) where T : class;
    }
}
