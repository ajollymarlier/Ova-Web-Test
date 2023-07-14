using Microsoft.AspNetCore.Identity;
using OvaWebTest.Domain;

namespace OvaWebTest.Persistence
{
    interface IUserRepository :
        IUserStore<User>,
        IUserPasswordStore<User>,
        IUserEmailStore<User>
    { }
}
