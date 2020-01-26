/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/26/2020 11:27:28 PM
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
    public class StockAddClientValidator : AbstractValidator<StockAddDto>
    {
        public StockAddClientValidator()
        {
            RuleFor(x => x.ProductId)
               .Must(x => x != Guid.Empty)
               .WithMessage("ProductId cannot be zero");
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero");
            RuleFor(x => x.MinQuantity)
                .GreaterThan(0).WithMessage("Min-Quantity must be greater than zero");
        }
    }
}

