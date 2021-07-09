using Repository.DatabaseModels;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBrandsRepository
    {
        Task<T> CreateBrandAsync<T>(T model) where T : Brand;
    }
}
