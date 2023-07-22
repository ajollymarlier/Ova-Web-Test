using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using OvaWebTest.Application;
using OvaWebTest.Application.DTOs;
using OvaWebTest.Application.Exceptions;
using OvaWebTest.Presentation;
using OvaWebTest.Tests.Stubs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OvaWebTest.Domain;

namespace OvaWebTest.Tests.Unit.Presentation
{
    /// <summary>
    /// You are prohibited from modifying the unit tests already present in the project. 
    /// In addition, they must all be able to pass when handing over your test.
    /// TODO: Develop all the necessary unit tests in order to have adequate coverage of your code.
    /// </summary>
    [TestFixture]
    public class UserControllerTest
    {
        private UserStub userStub;
        private IUserService mockUserService;
        private UserController userController;

        [SetUp]
        public void SetUp()
        {
            userStub = new UserStub();
            mockUserService = Substitute.For<IUserService>();
            userController = new UserController(mockUserService);
        }

        //Sign Up Test Cases
        // -------------------------------------------------------------------------------------------------------

        [Test]
        public async Task GivenUserRegistration_WhenSignUpValidUser_ThenCreated()
        {
            UserDTO user = userStub.GivenAUserDTO();
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            mockUserService.CreateAsync(userSignUp).Returns(user);

            ObjectResult result = await userController.SignUp(userSignUp) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
        }

        [Test]
        public async Task GivenUserRegistration_WhenSignUpExistingUser_ThenBadRequest()
        {
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            mockUserService.CreateAsync(userSignUp).Throws(new UserAlreadyExistsException(userSignUp));

            ObjectResult result = await userController.SignUp(userSignUp) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public async Task GivenUserRegistration_WhenSignUpWithInvalidData_ThenBadRequest()
        {
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            mockUserService.CreateAsync(userSignUp).Throws(new UserCreationException(userSignUp, new List<string>()));

            ObjectResult result = await userController.SignUp(userSignUp) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public async Task GivenUserRegistration_WhenSignUpRaiseUnhandledException_ThenInternalServerError()
        {
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            mockUserService.CreateAsync(userSignUp).Throws(new Exception("An error occured."));

            ObjectResult result = await userController.SignUp(userSignUp) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        //Find User Profile Test Cases
        // --------------------------------------------------------------------------------------------------------------------

        [Test]
        public async Task GivenUserName_WhenSearchExistingUser_ThenOK()
        {
            UserDTO user = userStub.GivenAUserDTO();
            mockUserService.GetProfileAsync(user.UserName).Returns(user);

            ObjectResult result = await userController.GetUserProfile(user.UserName) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }

        [Test]
        public async Task GivenUserName_WhenSearchNonExisitingUser_ThenBadRequest()
        {
            UserDTO user = userStub.GivenAUserDTO();
            mockUserService.GetProfileAsync(user.UserName).Throws(new UserNotFoundException(user.UserName));

            ObjectResult result = await userController.GetUserProfile(user.UserName) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }   

        [Test]
        public async Task GivenUserName_WhenSearchRaiseUnhandledException_ThenInternalServerError()
        {
            UserDTO user = userStub.GivenAUserDTO();
            mockUserService.GetProfileAsync(user.UserName).Throws(new Exception("An error occurred."));

            ObjectResult result = await userController.GetUserProfile(user.UserName) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        //Delete User Test Cases
        // ------------------------------------------------------------------------------------------------------------

        [Test]
        public async Task GivenUserName_WhenDeleteExistingUser_ThenOK()
        {
            UserDTO user = userStub.GivenAUserDTO();
            await mockUserService.DeleteAsync(user.UserName);

            ObjectResult result = await userController.DeleteUser(user.UserName) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }

        [Test]
        public async Task GivenUserName_WhenDeleteNonExistingUser_ThenBadRequest()
        {
            UserDTO user = userStub.GivenAUserDTO();
            mockUserService.DeleteAsync(user.UserName).Throws(new UserNotFoundException(user.UserName));

            ObjectResult result = await userController.DeleteUser(user.UserName) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Test]
        public async Task GivenUserName_WhenDeleteRaiseUnhandledException_ThenInternalServerError()
        {
            UserDTO user = userStub.GivenAUserDTO();
            mockUserService.DeleteAsync(user.UserName).Throws(new Exception("An error occurred."));

            ObjectResult result = await userController.DeleteUser(user.UserName) as ObjectResult;

            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
