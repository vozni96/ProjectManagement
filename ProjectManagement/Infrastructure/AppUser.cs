using System;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.Infrastructure
{
    public class AppUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
    }
}