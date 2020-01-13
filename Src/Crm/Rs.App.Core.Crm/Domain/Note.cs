/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/12/2020 7:58:51 PM
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Domain
{
    public class Note
    {
        public Note()
        {           
        }

        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string ShortNote { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;


        public virtual Contact Contact { get; set; }
    }
}
