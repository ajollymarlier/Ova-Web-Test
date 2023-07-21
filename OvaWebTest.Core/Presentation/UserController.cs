using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVA.StellarXWebPortal.Presentation.Controllers.HttpResponses;
using OvaWebTest.Application;
using OvaWebTest.Application.DTOs;
using System;
using System.Threading.Tasks;
using OvaWebTest.Application.Exceptions;

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
        /// </summary>
        /// <param name="userSignUpDTO">The sign up request</param>
        /// <returns>A status code</returns>
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpDTO userSignUpDTO)
        {
            ObjectResult finalCodeRes;

            try{ 
                UserDTO userDTO = await userService.CreateAsync(userSignUpDTO); 
                finalCodeRes = StatusCode(StatusCodes.Status201Created, userDTO);
            }
            catch (UserAlreadyExistsException e){
                finalCodeRes = StatusCode(StatusCodes.Status400BadRequest, userSignUpDTO);
            }
            catch (UserCreationException e){
                finalCodeRes = StatusCode(StatusCodes.Status400BadRequest, userSignUpDTO);
            }
            catch {
                finalCodeRes = StatusCode(StatusCodes.Status500InternalServerError, userSignUpDTO);
            }

            return finalCodeRes;
        }

        /// <summary>
        /// Fetch a specific user information.
        /// </summary>
        /// <param name="userName">the user's username</param>
        /// <returns>A status code</returns>
        [Route("profile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile(string userName)
        {
            ObjectResult finalCodeRes;

            try {
                UserDTO userDTO = await userService.GetProfileAsync(userName);
                finalCodeRes = StatusCode(StatusCodes.Status200OK, userDTO);
            }
            catch (UserNotFoundException e){
                finalCodeRes = StatusCode(StatusCodes.Status400BadRequest, userName);
            }
            catch {
                finalCodeRes = StatusCode(StatusCodes.Status500InternalServerError, userName);
            }

            return finalCodeRes;    
        }

        /// <summary>
        /// Delete a specific user.
        /// </summary>
        /// <param name="userName">the user's username</param>
        /// <returns>A status code</returns>
        [Route("profile/delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            try{
                await userService.DeleteAsync(userName);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch{
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
