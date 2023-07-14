using System;

namespace OvaWebTest.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string userName) : base($"Could not find user with username: {userName}.") { }
    }
}
