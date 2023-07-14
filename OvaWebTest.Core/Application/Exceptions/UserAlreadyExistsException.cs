using OvaWebTest.Application.DTOs;
using System;

namespace OvaWebTest.Application.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(UserSignUpDTO userSignUpDTO)
            : base($"Could not create user: {userSignUpDTO.UserName} ({userSignUpDTO.FirstName} {userSignUpDTO.LastName}). User already exists.") { }
    }
}
