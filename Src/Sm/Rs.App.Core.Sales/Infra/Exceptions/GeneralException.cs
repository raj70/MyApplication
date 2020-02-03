/** 
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Sales.Infra.Exceptions
{

    [Serializable]
    public class GeneralException : Exception
    {
        public GeneralException() { }
        public GeneralException(string message) : base(message) { }
        public GeneralException(string message, GeneralException inner) : base(message, inner) { }
        protected GeneralException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

