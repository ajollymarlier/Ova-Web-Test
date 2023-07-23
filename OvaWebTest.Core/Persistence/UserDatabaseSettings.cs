using System;
using Microsoft.AspNetCore.Identity;
using OvaWebTest.Domain;

namespace OvaWebTest.Persistence
{
    public class UserDatabaseSettings : IUserDatabaseSettings
    { 
        public string UserCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}