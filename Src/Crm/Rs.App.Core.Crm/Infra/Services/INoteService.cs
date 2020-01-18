/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/18/2020 4:45:22 PM
* 
* [%clrversion%]
*/
using Rs.App.Core.Crm.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Services
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotesAsync(Guid contactId);
        Task<Result> AddAsync(NoteAdd note);
        Task<Result> UpdateAsync(Guid noteId, NoteUpdate note);
        Task<Result> DeleteAsync(Guid noteId);
    }
}
