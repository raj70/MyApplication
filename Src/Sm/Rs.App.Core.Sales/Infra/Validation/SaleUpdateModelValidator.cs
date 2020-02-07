/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 2/7/2020 2:52:47 PM
*/
using FluentValidation;
using FluentValidation.Results;
using Rs.App.Core.Sales.Application.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Validation
{
    public class SaleUpdateModelValidator : AbstractValidator<SaleUpdateClientModel>
    {
        public SaleUpdateModelValidator()
        {
            RuleFor(x => x.TotalCost).Custom((x, c) =>
            {
                if (x.HasValue)
                {
                    if(x.Value <= 0)
                    {
                        c.AddFailure(new ValidationFailure(nameof(SaleUpdateClientModel.TotalCost), "TotalCost has incorrect values"));
                    }
                    
                }
            });
        }
    }
}

