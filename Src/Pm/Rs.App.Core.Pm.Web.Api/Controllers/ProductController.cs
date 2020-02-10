using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rs.App.Core.Pm.Application.Dtos;
using Rs.App.Core.Pm.Application.Services;
using Rs.App.Core.Pm.Infra.Domain;

namespace Rs.App.Core.Pm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{productId}", Name = "GetProduct")]
        public async Task<ActionResult> GetProduct(Guid productId)
        {
            var product = await _productService.GetAsync(productId);

            if (product == null)
            {
                var result = new Result()
                {
                    IsError = true,
                    Message = "Product not found",
                    StatuCode = 400
                };
                return BadRequest(result);
            }

            return Ok(product);
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

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<ActionResult> Delete(ProductRemoveDto removeDto)
        {
            var result = await _productService.DeleteAsync(removeDto);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}