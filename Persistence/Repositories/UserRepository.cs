using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.API.Domain.Models;
using Users.API.Domain.Repositories;
using Users.API.Persistence.Contexts;

namespace Users.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(User User)
        {
            await _context.Users.AddAsync(User);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User User)
        {
            _context.Users.Update(User);
        }

        public void Remove(User User)
        {
            _context.Users.Remove(User);
        }
    }
}