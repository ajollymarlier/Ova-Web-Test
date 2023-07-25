using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OvaWebTest.Domain;
using OvaWebTest.Application.DTOs;
using MongoDB.Driver;
using ZstdSharp.Unsafe;
using System.Collections.Generic;

namespace OvaWebTest.Persistence
{
    public class UserDatabaseManager : IUserDatabaseManager
    { 
        private readonly IMongoCollection<User> _users;
        public UserDatabaseManager(IUserDatabaseSettings settings, IMongoClient mongoClient){
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public async Task<IdentityResult> CreateAsync(User user) 
        {
            long numFound = _users.Find(tempUser => tempUser.UserName == user.UserName).CountDocuments();

            if (numFound > 0){
                return IdentityResult.Failed();
            }

            try{
                await _users.InsertOneAsync(user);
                return IdentityResult.Success;
            }
            catch{
                return null;
            }
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            IAsyncCursor<User> cursor = null;
            List<User> userList = null;

            try {
                cursor = await _users.FindAsync(user => user.UserName == userName);
                userList = await cursor.ToListAsync();
                return userList[0];
            }
            catch{
                return null;
            }
        }

        public async Task<IdentityResult> DeleteAsync(User user)
        {
            try{
                await _users.DeleteOneAsync(searchUser => searchUser.UserName == user.UserName);
                return IdentityResult.Success;
            }
            catch{
                return null;
            }
        }
    }
}