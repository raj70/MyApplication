using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet(Name = "GetNotUsed")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAllNotUsed()
        {
            var addresses = new List<Address>();

            var list = await _addressService.AllNotUsed();
            if (list != null)
            {
                addresses = list.ToList();
            }

            return Ok(addresses);
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public async Task<Address> Get(Guid id)
        {
            var address = await _addressService.GetAddress(id);
            return address;
        }

        [HttpDelete(Name ="DeleteNotUsed")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _addressService.DeleteAsync(id);
            if (result.IsError)
            {
                result.StatuCode = 400;
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}