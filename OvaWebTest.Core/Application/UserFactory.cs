using OvaWebTest.Application.DTOs;
using OvaWebTest.Domain;

namespace OvaWebTest.Application
{
    public class UserFactory
    {
        public User Create(UserSignUpDTO userSignUpDTO)
        {
            return new User()
            {
                UserName = userSignUpDTO.UserName,
                FirstName = userSignUpDTO.FirstName,
                LastName = userSignUpDTO.LastName,
                Email = userSignUpDTO.Email,
                PasswordHash = userSignUpDTO.Password
            };
        }
    }
}
