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
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, new { data = product });
        }

        // MÉTODO PARA ACTUALIZAR UN PRODUCTO
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
                throw new AppException("PRODUCT NOT FOUND", (int)HttpStatusCode.NotFound);

            product.Id = id;
            await _productService.UpdateAsync(product);
            return Ok(new { data = product });
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
