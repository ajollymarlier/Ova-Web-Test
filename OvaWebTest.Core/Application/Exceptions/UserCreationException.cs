using OvaWebTest.Application.DTOs;
using System;
using System.Collections.Generic;

namespace OvaWebTest.Application.Exceptions
{
    public class UserCreationException : Exception
    {
        public IEnumerable<object> Errors { get; private set; }

        public UserCreationException(UserSignUpDTO userSignUpDTO, IEnumerable<object> errors)
            : base($"Could not create user: {userSignUpDTO.UserName} ({userSignUpDTO.FirstName} {userSignUpDTO.LastName}). An error occured.")
        {
            Errors = errors;
        }
    }
}
