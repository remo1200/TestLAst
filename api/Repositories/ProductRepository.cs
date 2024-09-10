using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _sqlDbContext;

        public ProductRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }


        ///<inheritdoc/>
        public async Task Create(Product product)
        {
            _sqlDbContext.Products.Add(product);
            await _sqlDbContext.SaveChangesAsync();

        }

        ///<inheritdoc/>
        public async Task Delete(int id)
        {
            var product = await _sqlDbContext.Products.FindAsync(id);
            _sqlDbContext.Products.Remove(product);
            await _sqlDbContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _sqlDbContext.Products.Include(p => p.Category).ToListAsync();
        }

        ///<inheritdoc/>
        public async Task<Product> GetById(int id)
        {
            return await _sqlDbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        ///<inheritdoc/>
        public async Task Update(Product product)
        {
            _sqlDbContext.Products.Update(product);
            await _sqlDbContext.SaveChangesAsync();
        }
    }

}