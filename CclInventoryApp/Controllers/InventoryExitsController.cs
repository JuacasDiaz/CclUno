using CclInventoryApp.Exceptions;
using CclInventoryApp.Models;
using CclInventoryApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using CclInventoryApp.Dtos;

namespace CclInventoryApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class InventoryExitsController : ControllerBase
    {
        private readonly IInventoryExitService _inventoryExitService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        // CONSTRUCTOR DEL CONTROLADOR
        public InventoryExitsController(IInventoryExitService inventoryExitService, IProductService productService, IUserService userService)
        {
            _inventoryExitService = inventoryExitService;
            _productService = productService;
            _userService = userService;
        }

        // MÉTODO PARA OBTENER TODAS LAS SALIDAS DE INVENTARIO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventoryExits = await _inventoryExitService.GetAllAsync();
            return Ok(new { data = inventoryExits });
        }

        // MÉTODO PARA OBTENER UNA SALIDA DE INVENTARIO POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventoryExit = await _inventoryExitService.GetByIdAsync(id);
            if (inventoryExit == null)
                throw new AppException("INVENTORY EXIT NOT FOUND", (int)HttpStatusCode.NotFound);

            return Ok(new { data = inventoryExit });
        }

        // MÉTODO PARA CREAR UNA NUEVA SALIDA DE INVENTARIO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventoryExitDto inventoryExitDto)
        {
            // Verificar si el producto existe
            var product = await _productService.GetByIdAsync(inventoryExitDto.ProductId);
            if (product == null)
            {
                ModelState.AddModelError("Product", "The Product field is required.");
                return BadRequest(ModelState);
            }

            // Verificar si el usuario existe
            var user = await _userService.GetByIdAsync(inventoryExitDto.UserId);
            if (user == null)
            {
                ModelState.AddModelError("User", "The User field is required.");
                return BadRequest(ModelState);
            }

            // Crear la salida de inventario
            var inventoryExit = new InventoryExit
            {
                ProductId = inventoryExitDto.ProductId,
                UserId = inventoryExitDto.UserId,
                Quantity = inventoryExitDto.Quantity,
                Reason = inventoryExitDto.Reason
            };

            await _inventoryExitService.AddAsync(inventoryExit);
            return CreatedAtAction(nameof(GetById), new { id = inventoryExit.Id }, new { data = inventoryExit });
        }

        // MÉTODO PARA ACTUALIZAR UNA SALIDA DE INVENTARIO
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryExit inventoryExit)
        {
            var existingExit = await _inventoryExitService.GetByIdAsync(id);
            if (existingExit == null)
                throw new AppException("INVENTORY EXIT NOT FOUND", (int)HttpStatusCode.NotFound);

            inventoryExit.Id = id;
            await _inventoryExitService.UpdateAsync(inventoryExit);
            return Ok(new { data = inventoryExit });
        }

        // MÉTODO PARA ELIMINAR UNA SALIDA DE INVENTARIO
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingExit = await _inventoryExitService.GetByIdAsync(id);
            if (existingExit == null)
                throw new AppException("INVENTORY EXIT NOT FOUND", (int)HttpStatusCode.NotFound);

            await _inventoryExitService.DeleteAsync(id);
            return NoContent();
        }
    }
}
