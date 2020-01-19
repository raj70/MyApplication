/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/16/2020 4:20:49 PM
*/
using FluentValidation;
using Rs.App.Core.Crm.Application.ClientModel;
using System;

namespace Rs.App.Core.Crm.Infra.Validation
{
    public class ContactUpdateModelValidator : AbstractValidator<ContactUpdate>
    {
        public ContactUpdateModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Contact Name is empty")
                .MaximumLength(25).WithMessage("Name must be less or equal to 25 chars");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last Name is empty")
                .MaximumLength(25).WithMessage("Last Name must be less or equal to 25 chars");


            RuleFor(c => c.MobileNumber)
                .Must(ValidationUtil.IsCheckLength).WithMessage("Please check mobile number")
                .Must(ValidationUtil.IsValidNumber).WithMessage("Not a valid mobile number");

            RuleFor(c => c.PhoneNumber)
                .Must(ValidationUtil.IsCheckLength).WithMessage("Please check phone number")
                .Must(ValidationUtil.IsValidNumber).WithMessage("Not a valid phone number");

            RuleFor(c => c.PhoneNumber)
                .Must(ValidationUtil.OnePhoneNumberIsRequired).WithMessage("Phone number or mobile number must be provided");

            RuleFor(c => c.Dob)
                .NotEmpty().WithMessage("Dob is required")
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Age must be greater than 18");

            // why people will use it
            RuleFor(c => c.Dod).LessThan(DateTime.Now).WithMessage("Not able used future date (or today's date)");

            RuleFor(c => c.EmailAddress)
                .Must(ValidationUtil.IsValidEmailAddress).WithMessage("Not a valid email address");
        }
    }
}

