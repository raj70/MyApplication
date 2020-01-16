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
using Rs.App.Core.Crm.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Validation
{
    public class ContactClientModelValidator : AbstractValidator<ContactClient>
    {
        public ContactClientModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Contact Name is empty")
                .MaximumLength(25).WithMessage("Name must be less or equal to 25 chars");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last Name is empty")
                .MaximumLength(25).WithMessage("Last Name must be less or equal to 25 chars");


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

            // Home Address

            RuleFor(a => a.HomeLine1)
               .NotEmpty().WithMessage("Line1 is requried")
               .Length(5, 150).WithMessage("Not a valid address");
            RuleFor(a => a.HomeCity).NotEmpty().WithMessage("City is required");
            RuleFor(a => a.HomeState).NotEmpty().WithMessage("State is required");
            RuleFor(a => a.HomeCountry).NotEmpty().WithMessage("Country is required");
            RuleFor(a => a.HomePostalCode).Must((a, b) =>
            {
                bool isOk = true;
                if (a.HomeCountry == "Australia")
                {
                    isOk = a.HomePostalCode.Length == 4;
                }
                return isOk;
            });



            When(x => !x.IsDeliverSameAsHomeAddress, () =>
            {
                RuleFor(x => x.DeliveryCity)
                    .NotEmpty().WithMessage("Line1 is required");
                RuleFor(a => a.DeliveryLine1)
                   .NotEmpty().WithMessage("Line1 is requried")
                   .Length(5, 150).WithMessage("Not a valid address");
                RuleFor(a => a.DeliveryCity).NotEmpty().WithMessage("City is required");
                RuleFor(a => a.DeliveryState).NotEmpty().WithMessage("State is required");
                RuleFor(a => a.DeliveryCountry).NotEmpty().WithMessage("Country is required");
                RuleFor(a => a.DeliveryPostalCode).Must((a, b) =>
                {
                    bool isOk = true;
                    if (a.DeliveryCountry == "Australia")
                    {
                        isOk = a.DeliveryPostalCode.Length == 4;
                    }
                    return isOk;
                });
            });

        }

        private bool IsSameAddress(ContactClient contact, string v)
        {
            return contact.IsDeliverSameAsHomeAddress;
        }

        private bool IsCheckLength(ContactClient contact, string number)
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

        private bool OnePhoneNumberIsRequired(ContactClient contact, string number)
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

        private bool IsValidNumber(ContactClient instance, string number)
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
}

