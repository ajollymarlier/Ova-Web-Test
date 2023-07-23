using Microsoft.AspNetCore.Identity;
using OvaWebTest.Domain;

namespace OvaWebTest.Persistence
{
    public interface IUserDatabaseSettings
    { 
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}