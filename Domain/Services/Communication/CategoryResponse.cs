using Users.API.Domain.Models;

namespace Users.API.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="User">Saved User.</param>
        /// <returns>Response.</returns>
        public UserResponse(User User) : base(User)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : base(message)
        { }
    }
}