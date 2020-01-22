/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/21/2020 11:22:44 PM
* 
* [%clrversion%]
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core.Pm.Infra.Repository
{
    public interface IAuditRepository: IURepository
    {
        void Add(string value);
    }
}
