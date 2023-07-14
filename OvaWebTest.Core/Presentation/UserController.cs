using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVA.StellarXWebPortal.Presentation.Controllers.HttpResponses;
using OvaWebTest.Application;
using OvaWebTest.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace OvaWebTest.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly HttpResponseAssembler httpResponseAssembler;

        public UserController(IUserService userService)
        {
            this.userService = userService;

            httpResponseAssembler = new HttpResponseAssembler();
        }

        /// <summary>
        /// Create a user from a sign up request.
        /// TODO: Program all error handling for the user creation functionality.
        /// </summary>
        /// <param name="userSignUpDTO">The sign up request</param>
        /// <returns>A status code</returns>
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpDTO userSignUpDTO)
        {
            UserDTO userDTO = await userService.CreateAsync(userSignUpDTO);

            return StatusCode(StatusCodes.Status201Created, userDTO);
        }

        /// <summary>
        /// Fetch a specific user information.
        /// TODO: Program the entire functionality to fetch user information.
        /// </summary>
        /// <param name="userName">the user's username</param>
        /// <returns>A status code</returns>
        [Route("profile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a specific user.
        /// TODO: Program the entire user deletion functionality.
        /// </summary>
        /// <param name="userName">the user's username</param>
        /// <returns>A status code</returns>
        [Route("profile/delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
