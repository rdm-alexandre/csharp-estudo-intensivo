using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dia3_aspNetIntroducao.Models;
using dia3_aspNetIntroducao.Services;

namespace dia3_aspNetIntroducao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        
        public ProductsController (ProductService produtoService)
        {
            _productService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _productService.FindByIdAsync(id);
            if (product == null)
                return NotFound();
            
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Product product)
        {
            var newProduct = await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = newProduct.Id}, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
        
    }
}