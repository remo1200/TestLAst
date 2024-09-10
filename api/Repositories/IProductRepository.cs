using api.Models;

namespace api.Repositories
{


    public interface IProductRepository
    {

        /// <summary>
        /// Gets all Product(s)
        /// </summary>
        /// <returns>Returns a task to get all Product(s)</returns>
        Task<IEnumerable<Product>> GetAll();

        /// <summary>
        /// Gets Product by Id
        /// </summary>
        /// <returns>Returns a task to get Product by Id</returns>
        Task<Product> GetById(int id);

        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <returns>Returns a task to create a new Product</returns>
        Task Create(Product product);

        /// <summary>
        /// Updates a new Product
        /// </summary>
        /// <returns>Returns a task to update a Product</returns>
        Task Update(Product product);

        /// <summary>
        /// Deletes a Product
        /// </summary>
        /// <returns>Returns a task to delete a Product</returns>
        Task Delete(int id);

    }
}