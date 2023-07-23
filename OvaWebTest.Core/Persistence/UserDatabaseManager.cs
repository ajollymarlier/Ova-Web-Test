using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OvaWebTest.Domain;
using OvaWebTest.Application.DTOs;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace OvaWebTest.Persistence
{
    public class UserDatabaseManager : IUserDatabaseManager
    { 
        private readonly IMongoCollection<User> _users;
        public UserDatabaseManager(IUserDatabaseSettings settings, IMongoClient mongoClient){
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public async Task<IdentityResult> CreateAsync(User user) //TODO is this supposed to be async?
        {
            try{
                _users.InsertOne(user);
                return IdentityResult.Success;
            }
            catch{
                return null;
            }
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            try {
                return _users.Find(user => user.UserName == userName).FirstOrDefault();
            }
            catch{
                return null;
            }
            
        }

        public async Task<IdentityResult> DeleteAsync(User user)
        {
            try{
                _users.DeleteOne(searchUser => searchUser.UserName == user.UserName);
                return IdentityResult.Success;
            }
            catch{
                return null;
            }
        }
    }
}