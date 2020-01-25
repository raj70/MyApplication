/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/25/2020 2:16:46 PM
*/
using FluentValidation;
using Rs.App.Core.Pm.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Pm.Infra.Validatation
{
    public class ProductAddClientValidator: AbstractValidator<ProductAddDto>
    {
        public ProductAddClientValidator()
        {
            RuleFor(x => x.Cost)
               .GreaterThan(0).WithMessage("Cost cannot be zero");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is empty");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is empty");
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity cannot be zero");
            RuleFor(x => x.IsActive)
                .Must(x => x == false).WithMessage("The product cannot be inactive");

        }
    }
}

