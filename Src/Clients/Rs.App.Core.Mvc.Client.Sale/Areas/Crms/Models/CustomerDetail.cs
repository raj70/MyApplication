using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.Models
{
    public class CustomerDetail
    {
        public string Title { get; set; } = "Mr";
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; }

        public bool? IsActive { get; set; } = true;

        public DateTime? Dob { get; set; } = DateTime.Now.AddYears(-18);
        public DateTime? Dod { get; set; }
    }
}
