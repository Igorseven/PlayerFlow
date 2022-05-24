using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PlayerFlowX.Domain.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
