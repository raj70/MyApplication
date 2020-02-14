using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.App.Core.Mvc.Client.Sale.Areas.Crms.ViewModel
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Line1 { get; set; } = string.Empty;
        public string Line2 { get; set; } = string.Empty;
        public string Line3 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        [Display(Name="Postal Code")]
        public string PostalCode { get; set; } = string.Empty;
    }
}
