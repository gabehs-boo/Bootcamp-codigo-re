using System.Collections.Generic;
using System.Threading.Tasks;
using Users.API.Domain.Models;
using Users.API.Domain.Services.Communication;

namespace Users.API.Domain.Services
{
    public interface IUserService
    {
         Task<IEnumerable<User>> ListAsync();
         Task<UserResponse> SaveAsync(User User);
    }
}