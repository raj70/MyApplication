using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Sales.Application.ClientModel;
using Rs.App.Core.Sales.Application.Services;
using Rs.App.Core.Sales.Infra.Repository;

namespace Rs.App.Core.Sales.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IAuditRepository _auditRepository;

        public SalesController(ISaleService saleService, IAuditRepository auditRepository)
        {
            _saleService = saleService;
            _auditRepository = auditRepository;
        }

        [HttpGet(Name = "GetAllSales")]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAllSaleAsync(isActive: true);

            return Ok(sales);
        }

        [HttpGet("{salePersonId}", Name = "GetAllSalesFor")]
        public async Task<IActionResult> GetAll(Guid salePersonId)
        {
            var sales = await _saleService.GetAllSaleAsync(salePersonId, isActive: true);

            return Ok(sales);
        }

        [HttpPost(Name = "AddSales")]
        public async Task<IActionResult> Post([FromBody] SaleAddClientModel saleAddDto)
        {
            var result = await _saleService.AddAsync(saleAddDto);
            if (result.IsError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{salesId}", Name = "UpdateSales")]
        public async Task<IActionResult> Put(Guid salesId, [FromBody] SaleUpdateClientModel saleUpdateDto)
        {
            var result = await _saleService.UpdateSale(salesId, saleUpdateDto);

            if (result.IsError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}