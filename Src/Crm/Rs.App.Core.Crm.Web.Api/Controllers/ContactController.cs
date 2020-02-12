using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rs.App.Core.Crm.Application.ClientModel;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Exceptions;
using Rs.App.Core.Crm.Application.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IMapper mapper, IContactService contactService, ILogger<ContactController> logger)
        {
            _mapper = mapper;
            _contactService = contactService;
            _logger = logger;
        }
        // GET: api/Index
        [HttpGet(Name = "GetContacts")]
        public async Task<ActionResult<IEnumerable<ContactDetail>>> Get()
        {
            var contacts = await _contactService.GetAllAsync(pageIndex: 1);

            IEnumerable<ContactDetail> cs = new List<ContactDetail>();
            cs = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDetail>>(contacts);

            return Ok(cs);
        }

        // GET: api/Index/5
        [HttpGet("{id}", Name = "GetContact")]
        public async Task<ActionResult<ContactDetail>> Get(Guid id)
        {
            var contact = await _contactService.GetAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            var c = _mapper.Map<ContactDetail>(contact);

            return Ok(c);
        }

        // Add new
        // POST: api/Index
        [HttpPost(Name = "AddContact")]
        public async Task<IActionResult> Post([FromBody] ContactAddClient contact)
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
        [HttpPut("{id}", Name = "UpdateContact")]
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
            catch (CrmException ex)
            {
                _logger.LogError(ex, "Error has encounterd");
                return StatusCode(500);
            }// general exception should be handled by ExceptionMiddleware
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteContact")]
        [Authorize(Roles = "Admin")]
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
