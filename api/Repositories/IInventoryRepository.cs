using api.Models;

namespace api.Repositories
{


    public interface IInventoryRepository
    {

        /// <summary>
        /// Gets all Inventory(s)
        /// </summary>
        /// <returns>Returns a task to get all Inventory(s)</returns>
        Task<IEnumerable<Inventory>> GetAll();

        /// <summary>
        /// Gets Inventory by Id
        /// </summary>
        /// <returns>Returns a task to get Inventory by Id</returns>
        Task<Inventory> GetById(int id);

        /// <summary>
        /// Creates a new Inventory
        /// </summary>
        /// <returns>Returns a task to create a new Inventory</returns>
        Task Create(Inventory inventory);

        /// <summary>
        /// Updates a new Inventory
        /// </summary>
        /// <returns>Returns a task to update a Inventory</returns>
        Task Update(Inventory inventory);

        /// <summary>
        /// Deletes a Inventory
        /// </summary>
        /// <returns>Returns a task to delete a Inventory</returns>
        Task Delete(int id);

    }
}