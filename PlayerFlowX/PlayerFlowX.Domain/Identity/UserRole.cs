using Microsoft.AspNetCore.Identity;
using System;

namespace PlayerFlowX.Domain.Identity
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
