using Microsoft.AspNetCore.Identity;
using NSubstitute;
using NUnit.Framework;
using OVA.StellarXWebPortalTest.Mocks;
using OvaWebTest.Application;
using OvaWebTest.Application.DTOs;
using OvaWebTest.Application.Exceptions;
using OvaWebTest.Domain;
using OvaWebTest.Tests.Stubs;
using System.Threading.Tasks;

namespace OvaWebTest.Tests.Unit.Application
{
    /// <summary>
    /// You are prohibited from modifying the unit tests already present in the project. 
    /// In addition, they must all be able to pass when handing over your test.
    /// TODO: Develop all the necessary unit tests in order to have adequate coverage of your code.
    /// </summary>
    [TestFixture]
    public class UserServiceTest
    {
        private UserStub userStub;
        private MockUserManager mockUserManager;
        private IUserService userService;

        [SetUp]
        public void SetUp()
        {
            userStub = new UserStub();
            mockUserManager = Substitute.For<MockUserManager>();

            userService = new UserService(mockUserManager);
        }

        [Test]
        public async Task GivenCreationRequest_WhenCreatingUser_ThenUserDTOIsReturned()
        {
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            User userToCreate = userStub.GivenAUser();
            mockUserManager.CreateAsync(userToCreate).Returns(IdentityResult.Success);

            UserDTO userDTO = await userService.CreateAsync(userSignUp);

            Assert.AreEqual(userSignUp.UserName, userDTO.UserName);
            Assert.AreEqual(userSignUp.FirstName, userDTO.FirstName);
            Assert.AreEqual(userSignUp.LastName, userDTO.LastName);
            Assert.AreEqual(userSignUp.Email, userDTO.Email);
        }

        [Test]
        public void GivenUserAlreadyExists_WhenCreatingUser_ThenUserAlreadyExistsExceptionIsThrown()
        {
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            User user = userStub.GivenAUser();
            mockUserManager.FindByNameAsync(user.UserName).Returns(user);

            Assert.ThrowsAsync<UserAlreadyExistsException>(() => userService.CreateAsync(userSignUp));
        }

        [Test]
        public void GivenCreationRequest_WhenCreatingUserFailed_ThenUserCreationExceptionIsThrown()
        {
            UserSignUpDTO userSignUp = userStub.GivenAUserSignUpDTO();
            mockUserManager.CreateAsync(Arg.Any<User>()).Returns(IdentityResult.Failed());

            Assert.ThrowsAsync<UserCreationException>(() => userService.CreateAsync(userSignUp));
        }
    }
}
