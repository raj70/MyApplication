/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 12:10:20 AM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public interface IContactRepository : IRepository<Contact>
    {
        void CompleteAsync();
    }
}
