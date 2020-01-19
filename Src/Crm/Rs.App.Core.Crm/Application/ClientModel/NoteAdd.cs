/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/18/2020 4:47:06 PM
*/
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Application.ClientModel
{
    public class NoteAdd
    {
        public NoteAdd()
        {

        }

        public Guid ContactId { get; set; }
        public string ShortNote { get; set; }

        public virtual Note CreateNote()
        {
            return new Note
            {
                ContactId = ContactId,
                ShortNote = ShortNote
            };
        }
    }
}

