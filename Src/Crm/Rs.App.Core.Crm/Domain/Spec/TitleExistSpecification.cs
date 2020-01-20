/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/20/2020 8:44:28 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain.Spec
{
    public class TitleExistSpecification: ISpecification<Title>
    {
        private readonly string _titleName;

        public TitleExistSpecification(string titleName)
        {
            _titleName = titleName;
        }

        public Expression<Func<Title, bool>> SpecExpression()
        {
            return t => t.Name == _titleName;
        }
    }
}

