using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Crm.Application.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Application.Services;
using Rs.App.Core.Crm.Web.Api.Filters;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("{contactId}", Name = "GetNotes")]
        public async Task<ActionResult<IEnumerable<Note>>> Get(Guid contactId)
        {
            var notes = await _noteService.GetNotesAsync(contactId);

            if(notes == null)
            {
                return Ok(new List<Note>());
            }

            return Ok(notes);
        }

        
        [HttpPost(Name = "PostNote")]
        [ServiceFilter(typeof(ActionResultFilter))]
        public async Task<ActionResult> Post([FromBody] NoteAdd value)
        {
            var result = await _noteService.AddAsync(value);
            if (result.IsError)
            {
                result.StatuCode = 400;
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPut("{noteId}", Name = "UpdateNote")]
        public async Task<ActionResult> Put(Guid noteId, [FromBody] NoteUpdate value)
        {
            var result = await _noteService.UpdateAsync(noteId, value);
            if (result.IsError)
            {
                result.StatuCode = 400;
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPut("{parentNoteId}", Name = "AddChildNote")]
        public async Task<ActionResult> PutChildNote(Guid parentNoteId, [FromBody] NoteUpdate value)
        {
            var result = await _noteService.AddChildNote(parentNoteId, value);
            if (result.IsError)
            {
                result.StatuCode = 400;
                return BadRequest(result);
            }
            return Ok(result);
        }
        
        [HttpDelete("{noteId}", Name = "DeleteNote")]
        public async Task<ActionResult> Delete(Guid noteId)
        {
            var result = await _noteService.DeleteAsync(noteId);
            if (result.IsError)
            {
                result.StatuCode = 400;
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
