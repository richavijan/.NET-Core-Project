using System;
using System.Threading.Tasks;
using Core.Contract;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetProductAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetProductAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var result = await _productService.CreateProductAsync(product);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            var result = await _productService.UpdateProductAsync(id, product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return Ok(result);
        }

        [HttpGet("{productId}/options")]
        public async Task<IActionResult> GetOptions(int productId)
        {
            var result = await _productService.GetProductOptionsAsync(productId);
            return Ok(result);
        }

        [HttpGet("{productId}/options/{id}")]
        public async Task<IActionResult> GetOption(int productId, int id)
        {
            var result = await _productService.GetProductOptionsAsync(productId,id);
            return Ok(result);
        }

        [HttpPost("{productId}/options")]
        public async Task<IActionResult> PostOption(int productId, [FromBody] ProductOptions option)
        {
            var result = await _productService.CreateProductOptionsAsync(productId, option);
            return Ok(result);
        }

        [HttpPut("{productId}/options/{id}")]
        public async Task<IActionResult> PutOptions(int id, [FromBody] ProductOptions option)
        {
            var result = await _productService.UpdateProductOptionsAsync(id, option);
            return Ok(result);
        }

        [HttpDelete("{productId}/options/{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var result = await _productService.DeleteProductOptionsAsync(id);
            return Ok(result);
        }
    }
}