using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PlayerFlowX.Domain.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
