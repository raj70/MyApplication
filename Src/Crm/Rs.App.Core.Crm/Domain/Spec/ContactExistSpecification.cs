/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/20/2020 8:19:07 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain.Spec
{
    public class ContactExistSpecification : ISpecification<Contact>
    {
        private readonly Contact _contact;

        public ContactExistSpecification(Contact contact)
        {
            _contact = contact;
        }

        public Expression<Func<Contact, bool>> SpecExpression()
        {
            return x =>
                x.LastName.ToLower() == _contact.LastName.ToLower() &&
                x.Name.ToLower() == _contact.Name.ToLower() &&
                x.MiddleName.ToLower() == _contact.MiddleName.ToLower() &&
                x.MobileNumber.ToLower() == _contact.MobileNumber.ToLower() &&
                x.PhoneNumber.ToLower() == _contact.PhoneNumber.ToLower() &&
                x.Title.Id == _contact.TitleId &&
                x.Dob.Value.Date == _contact.Dob.Value.Date &&
                x.EmailAddress.ToLower() == _contact.EmailAddress.ToLower();
        }
    }
}

