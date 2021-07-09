using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.DatabaseModels;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private DbContext context;

        public BrandsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateBrandAsync<T>(T model) where T : Brand
        {
            var set = this.context.Set<T>();
            var record = await set.AddAsync(model);

            return record.Entity;
        }
    }
}
