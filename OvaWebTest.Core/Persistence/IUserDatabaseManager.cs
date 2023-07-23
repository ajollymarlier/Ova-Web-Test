using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OvaWebTest.Domain;

namespace OvaWebTest.Persistence
{
    public interface IUserDatabaseManager
    { 
        public Task<IdentityResult> CreateAsync(User user);
        public Task<User> FindByNameAsync(string userName);
        public Task<IdentityResult> DeleteAsync(User user);
    }
}