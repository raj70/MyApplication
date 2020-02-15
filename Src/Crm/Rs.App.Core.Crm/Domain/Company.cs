/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/14/2020 3:55:14 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain
{
    public class Company
    {
        public Company()
        {
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AddressId { get; set; }
        public Guid? DeliveryAddressId { get; set; }
        public Guid ContactPersonId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// GST, PAN or ABN
        /// </summary>
        public string BusinessNumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public virtual Address DeliveryAddress { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact ContactPerson { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
       
    }
}

