using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Services;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        // GET: api/Index
        [HttpGet(Name ="GetContacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            var contacts = await _contactService.GetAllAsync(1);

            return Ok(contacts);
        }

        // GET: api/Index/5
        [HttpGet("{id}", Name = "GetContact")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            var contact = await _contactService.GetAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // Add new
        // POST: api/Index
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            return NoContent();            
        }

        // update
        // PUT: api/Index/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Contact contact)
        {
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var contact = await _contactService.GetAsync(id);
            
            return NoContent();
        }
    }
}
