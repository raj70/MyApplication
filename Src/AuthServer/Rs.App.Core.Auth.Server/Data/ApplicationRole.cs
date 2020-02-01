using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Auth.Server.Data
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        [MaxLength(20)]
        public string Description { get; set; }
    }
}
