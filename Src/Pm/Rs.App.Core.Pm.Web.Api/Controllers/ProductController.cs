using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Application.Services;

namespace Rs.App.Core.Pm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("/GetStock/{productId}", Name = "GetStock")]
        public async Task<ActionResult> GetStock(Guid productId)
        {
            var products = await _productService.GetStock(productId);

            return Ok(products);
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public async Task<ActionResult> GetProduct(Guid productId)
        {
            var products = await _productService.Get(productId);

            return Ok(products);
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult> Post([FromBody]ProductAddDto productDto)
        {
            var result = await _productService.AddAsync(productDto);
            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}