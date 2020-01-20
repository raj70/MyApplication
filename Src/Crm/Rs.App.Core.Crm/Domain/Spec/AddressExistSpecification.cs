/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/20/2020 8:33:08 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain.Spec
{
    public class AddressExistSpecification : ISpecification<Address>
    {
        private readonly Address _address;

        public AddressExistSpecification(Address address)
        {
            _address = address;
        }

        public Expression<Func<Address, bool>> SpecExpression()
        {
            return address => _address.Line1 == address.Line1 &&
                               (_address.Line2 ?? "") == (address.Line2 ?? "") &&
                                (_address.Line3 ?? "") == (address.Line3 ?? "") &&
                               _address.City == address.City &&
                               _address.State == address.State &&
                               _address.Country == address.Country &&
                               _address.PostalCode == address.PostalCode;
        }
    }
}

