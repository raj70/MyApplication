/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/12/2020 7:41:47 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain
{
    // Tabular Module
    public class Contact
    {
        public Contact()
        {

        }

        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid DeliveryAddressId { get; set; }
        public Guid TitleId { get; set; }
        public Guid? CompanyId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string MobileNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string EmailAddress { get; set; }

        //The 'bool' property 'IsActive' on entity type 'Contact' is configured with a database-generated default. This default will always be used for inserts when the property has the value 'false', since this is the CLR default for the 'bool' type. Consider using the nullable 'bool?' type instead so that the default will only be used for inserts when the property value is 'null'
        public bool? IsActive { get; set; }

        public DateTime? Dob { get; set; } = DateTime.Now.AddYears(-18);
        public DateTime? Dod { get; set; }
        public bool IsDeliverSameAsHomeAddress
        {
            get
            {
                return AddressId.Equals(DeliveryAddressId);
            }
        }
        // not mapped
        public virtual Address DeliveryAddress { get; set; }
        public virtual Address HomeAddress { get; set; }
        public virtual Title Title { get; set; }
        public virtual Company Company { get; set; }
        public virtual Company CompanyContacts { get; set; }

        // one contact can have more notes
        public virtual ICollection<Note> Notes { get; set; }

    }
}
