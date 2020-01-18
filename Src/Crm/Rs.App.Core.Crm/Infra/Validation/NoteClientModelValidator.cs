﻿/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/18/2020 10:35:32 PM
*/
using FluentValidation;
using Rs.App.Core.Crm.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Validation
{
    public class NoteClientModelValidator : AbstractValidator<NoteAdd>
    {
        public NoteClientModelValidator()
        {
            RuleFor(c => c.ShortNote)
                .NotEmpty().WithMessage("Note cannot be empty")
                .MaximumLength(500).WithMessage("Note cannot excessed 500 chars");
        }
    }
}

