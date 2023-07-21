using Microsoft.AspNetCore.Identity;
using OvaWebTest.Application.DTOs;
using OvaWebTest.Domain;
using System;
using System.Threading.Tasks;
using OvaWebTest.Application.Exceptions;

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
        /// </summary>
        /// <param name="userSignUpDTO">The sign up request</param>
        /// <returns>The user information</returns>
        public async Task<UserDTO> CreateAsync(UserSignUpDTO userSignUpDTO)
        {
            User user = userFactory.Create(userSignUpDTO);

            IdentityResult ires = await userManager.CreateAsync(user);

            if (ires is null){
                throw new UserAlreadyExistsException(userSignUpDTO);
            }
            else if (ires != null && ires.Succeeded){
                return userDTOAssembler.Assemble(user);
            }
            else {
                throw new UserCreationException(userSignUpDTO, ires.Errors);
            }
        }

        /// <summary>
        /// Fetch a specific user information.
        /// </summary>
        /// <param name="userName">the user's username</param>
        /// <returns>The user information</returns>
        public async Task<UserDTO> GetProfileAsync(string userName)
        {
            User user = await userManager.FindByNameAsync(userName);

            if (user is null){
                throw new UserNotFoundException(userName);
            }
            else {
                return userDTOAssembler.Assemble(user);
            }
        }

        /// <summary>
        /// Delete a specific user.
        /// </summary>
        /// <param name="userName">the user's username</param>
        public async Task DeleteAsync(string userName)
        {
            User user = await userManager.FindByNameAsync(userName);
            IdentityResult iRes = await userManager.DeleteAsync(user);

            if (!iRes.Succeeded){
                throw new UserNotFoundException(userName);
            }
        }
    }
}
