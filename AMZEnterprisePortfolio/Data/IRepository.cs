using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterprisePortfolio.Data
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns>return all entity type data in a list</returns>
        Task<List<T>> GetAll();
        /// <summary>
        /// Get single data by it's primary key
        /// </summary>
        /// <param name="id">Entity type object primary key</param>
        /// <returns></returns>
        Task<T> Get(int id);
        /// <summary>
        /// Insert an Entity type
        /// </summary>
        /// <param name="entity">New Entity type object</param>
        /// <returns></returns>
        Task<T> Add(T entity);
        /// <summary>
        /// Update Entity type
        /// </summary>
        /// <param name="entity">Existing updated Entity type object</param>
        /// <returns></returns>
        Task<T> Update(T entity);
        /// <summary>
        /// Delete Entity type
        /// </summary>
        /// <param name="id">Entity type object primary key</param>
        /// <returns></returns>
        Task<T> Delete(int id);
    }
}
