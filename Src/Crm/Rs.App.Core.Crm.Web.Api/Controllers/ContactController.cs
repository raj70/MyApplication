using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rs.App.Core.Crm.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Exceptions;
using Rs.App.Core.Crm.Infra.Services;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }
        // GET: api/Index
        [HttpGet(Name = "GetContacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            var contacts = await _contactService.GetAllAsync(pageIndex: 1);

            return Ok(contacts);
        }

        // GET: api/Index/5
        [HttpGet("{id}", Name = "GetContact")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            var contact = await _contactService.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // Add new
        // POST: api/Index
        [HttpPost(Name ="AddContact")]
        public async Task<IActionResult> Post([FromBody] ContactClient contact)
        {
            try
            {
                var result = await _contactService.AddedAsync(contact);
                if (result.IsError)
                {
                    result.StatuCode = 400;
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error has encounterd");
                return StatusCode(500);
            }          
        }

        // update
        // PUT: api/Index/5
        [HttpPut("{id}", Name ="UpdateContact")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ContactUpdate contact)
        {
            try
            {
                var result = await _contactService.UpdateAsync(id, contact);
                if (result.IsError)
                {
                    result.StatuCode = 400;
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch(CrmException ex)
            {
                _logger.LogError(ex, "Error has encounterd");
                return StatusCode(500);
            }// general exception should be handled by ExceptionMiddleware
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name ="DeleteContact")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _contactService.DeleteAsync(id);

            if (result.IsError)
            {
                result.StatuCode = 400;
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
