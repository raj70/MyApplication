/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/14/2020 6:25:18 PM
*/
using Rs.App.Core.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Repository
{
    public sealed class NoteRepository : AbstractRepository<Note>, INoteRepository
    {
        private readonly NoteContext noteContext;
        public NoteRepository(NoteContext dbContext) : base(dbContext)
        {
            noteContext = dbContext;
        }

        public void Complete()
        {
            noteContext.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await noteContext.SaveChangesAsync();
        }

        public void Update(Guid noteId, Note note)
        {
            var exist_note = Find(x => x.Id == noteId).FirstOrDefault();
            if(exist_note != null)
            {
                exist_note.ShortNote = note.ShortNote;
                exist_note.UpdatedDate = note.UpdatedDate;
                noteContext.Entry(exist_note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                noteContext.SaveChanges();
            }
            else
            {
                throw new Exceptions.CrmException("Note does not exist");
            }
        }
    }
}
