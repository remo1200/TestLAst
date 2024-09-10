using api.Models;

namespace api.Repositories
{


    public interface ICategoryRepository
    {

        /// <summary>
        /// Gets all Category(s)
        /// </summary>
        /// <returns>Returns a task to get all Category(s)</returns>
        Task<IEnumerable<Category>> GetAll();

        /// <summary>
        /// Gets Category by Id
        /// </summary>
        /// <returns>Returns a task to get Category by Id</returns>
        Task<Category> GetById(int id);

        /// <summary>
        /// Creates a new Category
        /// </summary>
        /// <returns>Returns a task to create a new Category</returns>
        Task Create(Category category);

        /// <summary>
        /// Updates a new Category
        /// </summary>
        /// <returns>Returns a task to update a Category</returns>
        Task Update(Category category);

        /// <summary>
        /// Deletes a Category
        /// </summary>
        /// <returns>Returns a task to delete a Category</returns>
        Task Delete(int id);

    }
}