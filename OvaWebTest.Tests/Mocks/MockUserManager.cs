using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using OvaWebTest.Domain;
using System;
using System.Collections.Generic;

namespace OVA.StellarXWebPortalTest.Mocks
{
    public class MockUserManager : UserManager<User>
    {
        public MockUserManager()
            : base(Substitute.For<IUserStore<User>>(),
                   Substitute.For<IOptions<IdentityOptions>>(),
                   Substitute.For<IPasswordHasher<User>>(),
                   Substitute.For<IEnumerable<IUserValidator<User>>>(),
                   Substitute.For<IEnumerable<IPasswordValidator<User>>>(),
                   Substitute.For<ILookupNormalizer>(),
                   Substitute.For<IdentityErrorDescriber>(),
                   Substitute.For<IServiceProvider>(),
                   Substitute.For<ILogger<UserManager<User>>>())
        {
        }
    }
}
