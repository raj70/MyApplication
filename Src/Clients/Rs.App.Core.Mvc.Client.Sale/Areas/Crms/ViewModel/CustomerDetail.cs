using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.ViewModel
{
    public class CustomerDetail
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "Mr";
        public string Name { get; set; }
        [Display(Name= "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Mobile")]
        public string MobileNumber { get; set; } = string.Empty;
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? Dob { get; set; }
        public DateTime? Dod { get; set; }

        public bool IsDeliverSameAsHomeAddress { get; set; }
        public Guid HomeAddressId { get; set; }
        public Guid DeliveryAddressId { get; set; }
    }
}
