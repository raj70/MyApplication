/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/12/2020 7:44:14 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain
{
    public class Address
    {
        public Address()
        {
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Line1 { get; set; } = string.Empty;
        public string Line2 { get; set; } = string.Empty;
        public string Line3 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        

        public override bool Equals(object obj)
        {
            bool isSame = false;
            var newAddress = obj as Address;
            if (Line1.Equals(newAddress.Line1, StringComparison.OrdinalIgnoreCase) &&
                (Line2 ?? "").Equals((newAddress.Line2 ?? ""), StringComparison.OrdinalIgnoreCase) &&
                (Line3 ?? "").Equals((newAddress.Line3 ?? ""), StringComparison.OrdinalIgnoreCase) &&
                City.Equals(newAddress.City, StringComparison.OrdinalIgnoreCase) &&
                State.Equals(newAddress.State, StringComparison.OrdinalIgnoreCase) &&
                Country.Equals(newAddress.Country, StringComparison.OrdinalIgnoreCase) &&
                PostalCode.Equals(newAddress.PostalCode, StringComparison.OrdinalIgnoreCase))
            {
                isSame = true;
            }
            return isSame;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Line1};{Line2};{Line3};{City};{State};{Country};{PostalCode}";
        }

        public virtual Company Company { get; set; }
        public virtual Company DeliveryCompany { get; set; }
    }
}
