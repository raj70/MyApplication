using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Auth.Server.Data
{
    public enum EnumUserStatus { Submitted, Approved, Rejected }
    public enum EnumUserType { Saler, Buyer, Employee}
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() : base()
        {

        }
        /// <summary>
        /// contact id from crm or anyother system
        /// </summary>
        public Guid ContactId { get; set; }

        public EnumUserType UserType { get; set; }

        public EnumUserStatus Status { get; set; }

        public Guid? ParentUserId { get; set; }
    }
}
