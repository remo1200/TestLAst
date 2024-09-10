using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlDbContext _sqlDbContext;

        public CategoryRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }


        ///<inheritdoc/>
        public async Task Create(Category category)
        {
            _sqlDbContext.Categories.Add(category);
            await _sqlDbContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task Delete(int id)
        {
            var category = await _sqlDbContext.Categories.FirstOrDefaultAsync(p => p.Id == id);
            _sqlDbContext.Categories.Remove(category);
            await _sqlDbContext.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _sqlDbContext.Categories.ToListAsync();
        }

        ///<inheritdoc/>
        public async Task<Category> GetById(int id)
        {
            return await _sqlDbContext.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        ///<inheritdoc/>
        public async Task Update(Category category)
        {
            _sqlDbContext.Categories.Update(category);
            await _sqlDbContext.SaveChangesAsync();
        }
    }

}