using OvaWebTest.Application.DTOs;
using System.Threading.Tasks;

namespace OvaWebTest.Application
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(UserSignUpDTO userSignUpDTO);
        Task<UserDTO> GetProfileAsync(string userName);
        Task DeleteAsync(string userName);
    }
}
