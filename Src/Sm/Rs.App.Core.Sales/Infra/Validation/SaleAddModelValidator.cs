/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/7/2020 2:41:25 PM
*/
using FluentValidation;
using Rs.App.Core.Sales.Application.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Validation
{
    public class SaleAddModelValidator : AbstractValidator<SaleAddClientModel>
    {
        public SaleAddModelValidator()
        {
            RuleFor(x => x.TotalCost).GreaterThan(0.00M).WithMessage("Not a valid total");
            RuleFor(x => x.CustomerId).NotEqual(Guid.Empty).WithMessage("Not a valid customer");
            RuleFor(x => x.SalePersonId).NotEqual(Guid.Empty).WithMessage("Not a valid sales person");

            RuleFor(x => x.ProductIds).Custom((x, c) => {
                x.ForEach(id =>
                {
                    if (id.Equals(Guid.Empty))
                    {
                        c.AddFailure(nameof(SaleAddClientModel.ProductIds), $"{id}: Not a valid product id");
                    }
                });
            });
        }
    }
}

