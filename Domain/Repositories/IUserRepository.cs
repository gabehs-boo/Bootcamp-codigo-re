using System.Collections.Generic;
using System.Threading.Tasks;
using Users.API.Domain.Models;

namespace Users.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User User);
        Task<User> FindByIdAsync(int id);
    }
}