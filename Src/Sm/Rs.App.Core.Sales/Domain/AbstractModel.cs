﻿/** 
* Copyright 2020 rajen.shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: RAJDEVMAC rajen.shrestha
* Machine: RAJDEVMAC
* Time: 2/3/2020 7:46:14 PM
*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Domain
{
    public class AbstractModel
    {
        public AbstractModel()
        {

        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Name:" + this.GetType().Name + ", ");
            this.GetType().GetProperties().ToList().ForEach(x => {
                var property = x.Name;
                var value = x.GetValue(this);
                sb.Append(property + ":" + value);
                sb.Append(", ");
            });
            return sb.ToString();
        }
    }
}

