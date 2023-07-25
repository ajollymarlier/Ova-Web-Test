using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using OvaWebTest.Domain;
using System;
using System.Collections.Generic;
using OvaWebTest.Persistence;
using MongoDB.Driver;

namespace OVA.StellarXWebPortalTest.Mocks
{
    public class MockUserManager : UserDatabaseManager
    {
        public MockUserManager()
            : base(
                Substitute.For<IUserDatabaseSettings>(),
                Substitute.For<IMongoClient>()
            )
        {}
    }
}
