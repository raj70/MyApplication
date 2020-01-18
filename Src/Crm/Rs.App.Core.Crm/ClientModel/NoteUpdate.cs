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

namespace Rs.App.Core.Crm.ClientModel
{
    public class NoteUpdate : NoteAdd
    {
        public NoteUpdate()
        {

        }
        public DateTime UpdatedDate { get; internal set; } = DateTime.UtcNow;

        public override Note CreateNote()
        {
            return new Note
            {
                ContactId = ContactId,
                ShortNote = ShortNote,
                UpdatedDate = UpdatedDate
            };
        }
    }
}

