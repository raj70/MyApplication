using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Application.Services;
using Rs.App.Core.Pm.Infra.Domain;
using Rs.App.Core.Pm.Infra.Repository;

namespace Rs.App.Core.Pm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{productId}", Name = "GetStock")]
        public async Task<ActionResult> GetStock(Guid productId)
        {
            var stock = await _stockService.GetStockAsync(productId);

            if (stock == null)
            {
                var result = new Result()
                {
                    IsError = true,
                    Message = "Stock not found",
                    StatuCode = 400
                };
                return BadRequest(result);
            }

            return Ok(stock);
        }

        [HttpPut("{id}", Name = "ChangeQuantity")]
        public async Task<ActionResult> Put(Guid id, [FromBody] StockUpdateDto stockReduce)
        {
            var result = await _stockService.UpdateAsync(id, stockReduce);

            return Ok(result);
        }
    }
}