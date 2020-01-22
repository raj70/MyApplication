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
        //[HttpGet(Name ="GetProducts")]

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult> Post(ProductAddDto productDto)
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