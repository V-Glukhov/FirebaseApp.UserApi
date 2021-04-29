
using System.Threading.Tasks;
using UserApi.DAL.Models;
using UserApi.DAL.Repository.Abstraction;

namespace UserApi.DAL.Repository.Implementation
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        /// <inheritdoc />
        public Task<bool> Add(User dto)
        {
            return Task.FromResult(true);//TODO реализовать репозиторий, подключить EF Core, реализовать контекст и UnitOfWork
        }


        /// <inheritdoc />
        public Task<bool> Delete(string token)
        {
            return Task.FromResult(true);
        }
    }
}
