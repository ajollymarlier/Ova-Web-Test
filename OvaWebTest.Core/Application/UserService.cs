using Microsoft.AspNetCore.Identity;
using OvaWebTest.Application.DTOs;
using OvaWebTest.Domain;
using System;
using System.Threading.Tasks;

namespace OvaWebTest.Application
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly UserFactory userFactory;
        private readonly UserDTOAssembler userDTOAssembler;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;

            userFactory = new UserFactory();
            userDTOAssembler = new UserDTOAssembler();
        }

        /// <summary>
        /// Create a user from a sign up request.
        /// TODO: Program all error handling for the user creation functionality.
        /// </summary>
        /// <param name="userSignUpDTO">The sign up request</param>
        /// <returns>The user information</returns>
        public async Task<UserDTO> CreateAsync(UserSignUpDTO userSignUpDTO)
        {
            User user = userFactory.Create(userSignUpDTO);

            await userManager.CreateAsync(user);

            return userDTOAssembler.Assemble(user);
        }

        /// <summary>
        /// Fetch a specific user information.
        /// </summary>
        /// <param name="userName">the user's username</param>
        /// <returns>The user information</returns>
        public async Task<UserDTO> GetProfileAsync(string userName)
        {
            User user = await userManager.FindByNameAsync(userName);
            return userDTOAssembler.Assemble(user);
        }

        /// <summary>
        /// Delete a specific user.
        /// </summary>
        /// <param name="userName">the user's username</param>
        public async Task DeleteAsync(string userName)
        {
            User user = await userManager.FindByNameAsync(userName);
            IdentityResult iRes = await userManager.DeleteAsync(user);
        }
    }
}
