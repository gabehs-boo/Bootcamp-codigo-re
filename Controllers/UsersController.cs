using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Users.API.Domain.Models;
using Users.API.Domain.Services;
using Users.API.Resources;

namespace Users.API.Controllers
{
    [Route("/api/users")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;

        public UsersController(IUserService UserService, IMapper mapper)
        {
            _UserService = UserService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IEnumerable<UserResource>> ListAsync()
        {
            var Users = await _UserService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(Users);

            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            var User = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _UserService.SaveAsync(User);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var UserResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(UserResource);
        }
    }
}