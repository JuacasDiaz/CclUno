using CclInventoryApp.Dtos;
using CclInventoryApp.Exceptions;
using CclInventoryApp.Models;
using CclInventoryApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CclInventoryApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        // CONSTRUCTOR DEL CONTROLADOR
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // MÉTODO PARA OBTENER TODOS LOS PRODUCTOS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(new { data = products });
        }

        // MÉTODO PARA OBTENER UN PRODUCTO POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                throw new AppException("PRODUCT NOT FOUND", (int)HttpStatusCode.NotFound);

            return Ok(new { data = product });
        }

        // MÉTODO PARA CREAR UN NUEVO PRODUCTO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price
            };

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, new { data = product });
        }

        // MÉTODO PARA ACTUALIZAR UN PRODUCTO
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                throw new AppException("PRODUCT NOT FOUND", (int)HttpStatusCode.NotFound);

            existingProduct.Name = updateProductDto.Name;
            existingProduct.Description = updateProductDto.Description;
            existingProduct.Price = updateProductDto.Price;

            await _productService.UpdateAsync(existingProduct);
            return Ok(new { data = existingProduct });
        }

        // MÉTODO PARA ELIMINAR UN PRODUCTO
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                throw new AppException("PRODUCT NOT FOUND", (int)HttpStatusCode.NotFound);

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
