/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/26/2020 11:16:58 PM
*/
using FluentValidation;
using Rs.App.Core.Pm.Application.Dtos;
using System;

namespace Rs.App.Core.Pm.Infra.Validatation
{
    public class StockRemoveClientValidator : AbstractValidator<StockRemoveDto>
    {
        public StockRemoveClientValidator()
        {
            RuleFor(x => x.ProductId)
                .Must(x => x != Guid.Empty)
                .WithMessage("ProductId cannot be zero");

        }
    }
}

