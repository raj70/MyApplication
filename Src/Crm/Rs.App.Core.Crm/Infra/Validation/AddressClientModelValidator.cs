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

namespace Rs.App.Core.Crm.Infra.Validation
{
    public class AddressClientModelValidator : AbstractValidator<Address>
    {
        public AddressClientModelValidator()
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
