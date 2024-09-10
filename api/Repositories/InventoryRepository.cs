using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{

    public class InventoryRepository : IInventoryRepository
    {
        private readonly SqlDbContext _sqlDbContext;

        public InventoryRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }


        ///<inheritdoc/>
        public async Task Create(Inventory inventory)
        {
            _sqlDbContext.Inventories.Add(inventory);
            await _sqlDbContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task Delete(int ProductId)
        {
            var inventory = await _sqlDbContext.Inventories.FindAsync(ProductId);
            _sqlDbContext.Inventories.Remove(inventory);
            await _sqlDbContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _sqlDbContext.Inventories.Include(i => i.Product).ThenInclude(p => p.Category).ToListAsync();
        }

        ///<inheritdoc/>
        public async Task<Inventory> GetById(int productId)
        {
            return await _sqlDbContext.Inventories
                        .Include(i => i.Product)
                        .ThenInclude(p => p.Category)
                        .FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        ///<inheritdoc/>
        public async Task Update(Inventory inventory)
        {
            _sqlDbContext.Inventories.Update(inventory);
            await _sqlDbContext.SaveChangesAsync();
        }
    }

}