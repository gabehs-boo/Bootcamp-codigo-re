using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Users.API.Domain.Models;
using Users.API.Domain.Repositories;
using Users.API.Domain.Services;
using Users.API.Domain.Services.Communication;
using Users.API.Infrastructure;

namespace Users.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _UserRepository = UserRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            var Users = await _cache.GetOrCreateAsync(CacheKeys.UsersList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _UserRepository.ListAsync();
            });
            
            return Users;
        }

        public async Task<UserResponse> SaveAsync(User User)
        {
            try
            {
                await _UserRepository.AddAsync(User);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(User);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when saving the User: {ex.Message}");
            }
        }
    }
}
