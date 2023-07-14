using OvaWebTest.Domain;

namespace OvaWebTest.Application.DTOs
{
    public class UserDTOAssembler
    {
        public UserDTO Assemble(User user)
        {
            return new UserDTO()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
