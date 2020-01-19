using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Crm.Domain;
using Rs.App.Core.Crm.Infra.Repository;
using Rs.App.Core.Crm.Application.Services;

namespace Rs.App.Core.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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