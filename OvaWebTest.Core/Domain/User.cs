using Microsoft.AspNetCore.Identity;
using System;

namespace OvaWebTest.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User user)
        {
            if (user == null)
            {
                return false;
            }

            if (ReferenceEquals(this, user))
            {
                return true;
            }

            return NormalizedUserName == user.NormalizedUserName &&
                   NormalizedEmail == user.NormalizedEmail &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NormalizedUserName, NormalizedEmail, FirstName, LastName);
        }
    }
}
