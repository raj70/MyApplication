/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 1/18/2020 5:23:57 PM
*/
using Rs.App.Core.Crm.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Exceptions;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.Crm.Infra.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IContactRepository _contactRepository;

        public NoteService(INoteRepository noteRepository, IContactRepository contactRepository)
        {
            _noteRepository = noteRepository;
            _contactRepository = contactRepository;
        }

        public async Task<Result> AddAsync(NoteAdd note)
        {
            var n = note.CreateNote();
            var result = await Task.Run(() =>
            {
                var result = new Result();
                var c = _contactRepository.Get(n.ContactId);
                if (c == null)
                {
                    result.IsError = true;
                    result.Message = "Contact does not exist";
                    result.StatuCode = 400;
                }
                else
                {
                    _noteRepository.Add(n);
                    _noteRepository.Complete();
                }
                return result;
            });

            return result;
        }

        public async Task<Result> DeleteAsync(Guid noteId)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                _noteRepository.Remove(noteId);
                _noteRepository.Complete();
                return result;
            });
            return result;
        }

        public async Task<IEnumerable<Note>> GetNotesAsync(Guid contactId)
        {
            var notes = await Task.Run(() =>
            {
                return _noteRepository.Find(x => x.ContactId == contactId);
            });
            return notes;
        }

        public async Task<Result> UpdateAsync(Guid noteId, NoteUpdate note)
        {
            var result = await Task.Run(() =>
            {
                var result = new Result();

                var existed_note = _noteRepository.Find(x => x.Id == noteId).FirstOrDefault();
                if (existed_note == null)
                {
                    result.IsError = true;
                    result.Message = "Note does not exist";
                    result.StatuCode = 400;
                }
                else
                {
                    var c = note.CreateNote();                    
                    existed_note.ShortNote = c.ShortNote;
                    existed_note.UpdatedDate = c.UpdatedDate;

                    try
                    {
                        _noteRepository.Update(noteId, existed_note);
                    }
                    catch (CrmException ex)
                    {
                        result.IsError = true;
                        result.Message = ex.Message;
                        result.StatuCode = 400;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return result;
            });

            return result;
        }
    }
}

