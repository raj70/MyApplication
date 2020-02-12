/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/10/2020 9:01:17 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Application.ClientModel
{
    public class ContactDetail
    {
        public ContactDetail()
        {

        }

        public Guid Id { get; set; }
        public string Title { get; set; } = "Mr";
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? Dob { get; set; }
        public DateTime? Dod { get; set; }

        public bool IsDeliverSameAsHomeAddress { get; set; }
        public Guid HomeAddressId { get; set; }
        public Guid DeliveryAddressId { get; set; }
    }
}

