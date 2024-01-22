using DotNetCoreWebApiApplication.Models;
using DotNetCoreWebApiApplication.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    
    public class ProductController : ControllerBase
    {
        private readonly productServices _productService;

        public ProductController(productServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProductById")]
        public ActionResult<ProductModel> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult<ProductModel> AddProduct([FromBody] ProductModel product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data");
            }

            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel updatedProduct)
        {
            _productService.UpdateProduct(id, updatedProduct);
            return NoContent();
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
