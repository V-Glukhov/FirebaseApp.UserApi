using System.Threading.Tasks;
using UserApi.DAL.Models;

namespace UserApi.DAL.Repository.Abstraction
{
    /// <summary>
    /// IUserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Add(User dto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> Delete(string token);
    }
}
