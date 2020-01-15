/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/15/2020 10:01:09 PM
* 
* [%clrversion%]
*/
using FluentValidation;
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core.Crm.Validation
{
    public class ContactModelValidator : AbstractValidator<Contact>
    {
        public ContactModelValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(25);
            RuleFor(c => c.TitleId).NotEmpty();
        }
    }
}
