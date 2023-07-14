using System;
using System.Collections.Generic;

namespace OvaWebTest.Application.Exceptions
{
    public class UserDeletionException : Exception
    {
        public IEnumerable<object> Errors { get; private set; }

        public UserDeletionException(string userName, IEnumerable<object> errors)
            : base($"Could not delete user with username: {userName}.")
        {
            Errors = errors;
        }
    }
}
