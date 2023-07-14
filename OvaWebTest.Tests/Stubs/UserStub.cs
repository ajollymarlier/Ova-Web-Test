using OvaWebTest.Application.DTOs;
using OvaWebTest.Domain;

namespace OvaWebTest.Tests.Stubs
{
    public class UserStub
    {
        private const string UserName = "Boogeyman";
        private const string FirstName = "John";
        private const string LastName = "Wick";
        private const string Email = "john.wick@continentalhotel.com";
        private const string Password = "daisy";

        public User GivenAUser()
        {
            return new User()
            {
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PasswordHash = Password
            };
        }

        public UserDTO GivenAUserDTO()
        {
            return new UserDTO()
            {
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };
        }

        public UserSignUpDTO GivenAUserSignUpDTO()
        {
            return new UserSignUpDTO()
            {
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                ConfirmPassword = Password
            };
        }
    }
}