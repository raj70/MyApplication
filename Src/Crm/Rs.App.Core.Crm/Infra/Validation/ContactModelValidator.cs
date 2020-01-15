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
using System.Text.RegularExpressions;

namespace Rs.App.Core.Crm.Infra.Validation
{
    public class ContactModelValidator : AbstractValidator<Contact>
    {
        public ContactModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Contact Name is empty")
                .MaximumLength(25).WithMessage("Name must be less or equal to 25 chars");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last Name is empty")
                .MaximumLength(25).WithMessage("Last Name must be less or equal to 25 chars");

            RuleFor(c => c.TitleId).NotEmpty();
            RuleFor(c => c.TitleId)
                .Custom((g, c) =>
                {
                    if (g == Guid.Empty)
                    {
                        c.AddFailure("Guid is empty Guid");

                    }

                });

            RuleFor(c => c.MobileNumber)
                .Must(IsCheckLength).WithMessage("Please check mobile number")
                .Must(IsValidNumber).WithMessage("Not a valid mobile number");

            RuleFor(c => c.PhoneNumber)
                .Must(IsCheckLength).WithMessage("Please check phone number")
                .Must(IsValidNumber).WithMessage("Not a valid phone number");

            RuleFor(c => c.PhoneNumber)
                .Must(OnePhoneNumberIsRequired).WithMessage("Phone number or mobile number must be provided");

            RuleFor(c => c.Dob)
                .NotEmpty().WithMessage("Dob is required")
                .GreaterThan(DateTime.Now.AddYears(-18)).WithMessage("Age must be greater than 18");

            // why people will use it
            RuleFor(c => c.Dod).LessThan(DateTime.Now).WithMessage("Not able used future date (or today's date)");

            RuleFor(c => c.EmailAddress)
                .Must(IsValidEmailAddress).WithMessage("Not a valid email address");
        }

        private bool IsCheckLength(Contact contact, string number)
        {
            // not empty
            var mpn = !string.IsNullOrWhiteSpace(contact.MobileNumber);
            var pn = !string.IsNullOrWhiteSpace(contact.PhoneNumber);

            // if phone number or mobile number is not empty
            var isOk = OnePhoneNumberIsRequired(contact, number);
            if (isOk && mpn)
            {
                isOk = contact.MobileNumber.Length >= 7 && contact.MobileNumber.Length <= 16;
            }

            if (isOk && pn)
            {
                isOk = contact.PhoneNumber.Length >= 7 && contact.PhoneNumber.Length <= 16;
            }

            return isOk;
        }

        private bool OnePhoneNumberIsRequired(Contact contact, string number)
        {
            var mpn = contact.MobileNumber;
            var pn = contact.PhoneNumber;

            var isEmpty = !string.IsNullOrWhiteSpace(mpn);

            if (!isEmpty)
            {
                isEmpty = !string.IsNullOrWhiteSpace(pn);
            }

            return !string.IsNullOrWhiteSpace(mpn) || !string.IsNullOrWhiteSpace(pn);
        }

        private bool IsValidNumber(Contact instance, string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return true;
            }

            var pn = number.Trim().Replace(" ", "").Replace("-", "");
            long nu;
            return long.TryParse(pn, out nu);
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
        }
    }

    public class AddressModelValidator : AbstractValidator<Address>
    {
        public AddressModelValidator()
        {
            RuleFor(a => a.Line1)
                .NotEmpty().WithMessage("Line1 is requried")
                .Length(5, 150).WithMessage("Not a valid address");
            RuleFor(a => a.City).NotEmpty().WithMessage("City is required");
            RuleFor(a => a.State).NotEmpty().WithMessage("State is required");
            RuleFor(a => a.Country).NotEmpty().WithMessage("Country is required");

            RuleFor(a => a.PostalCode).Must((a, b) =>
            {
                bool isOk = true;
                if (a.Country == "Australia")
                {
                    isOk = a.PostalCode.Length == 4;
                }
                return isOk;
            });
        }
    }
}
