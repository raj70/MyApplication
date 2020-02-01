using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Auth.Server.Data
{
    public class AuthIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,  Guid>
    {
        public AuthIdentityDbContext(DbContextOptions<AuthIdentityDbContext> options)
           : base(options)
        {
        }
    }
   
}
