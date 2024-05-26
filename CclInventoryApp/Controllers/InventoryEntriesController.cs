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
    public class InventoryEntriesController : ControllerBase
    {
        private readonly IInventoryEntryService _inventoryEntryService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        // CONSTRUCTOR DEL CONTROLADOR
        public InventoryEntriesController(IInventoryEntryService inventoryEntryService, IProductService productService, IUserService userService)
        {
            _inventoryEntryService = inventoryEntryService;
            _productService = productService;
            _userService = userService;
        }

        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS DE INVENTARIO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventoryEntries = await _inventoryEntryService.GetAllAsync();
            return Ok(new { data = inventoryEntries });
        }

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventoryEntry = await _inventoryEntryService.GetByIdAsync(id);
            if (inventoryEntry == null)
                throw new AppException("INVENTORY ENTRY NOT FOUND", (int)HttpStatusCode.NotFound);

            return Ok(new { data = inventoryEntry });
        }

        // MÉTODO PARA CREAR UNA NUEVA ENTRADA DE INVENTARIO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventoryEntryDto inventoryEntryDto)
        {
            // Verificar si el producto existe
            var product = await _productService.GetByIdAsync(inventoryEntryDto.ProductId);
            if (product == null)
            {
                ModelState.AddModelError("Product", "The Product field is required.");
                return BadRequest(ModelState);
            }

            // Verificar si el usuario existe
            var user = await _userService.GetByIdAsync(inventoryEntryDto.UserId);
            if (user == null)
            {
                ModelState.AddModelError("User", "The User field is required.");
                return BadRequest(ModelState);
            }

            // Crear la entrada de inventario
            var inventoryEntry = new InventoryEntry
            {
                ProductId = inventoryEntryDto.ProductId,
                UserId = inventoryEntryDto.UserId,
                Quantity = inventoryEntryDto.Quantity,
                Method = inventoryEntryDto.Method
            };

            await _inventoryEntryService.AddAsync(inventoryEntry);
            return CreatedAtAction(nameof(GetById), new { id = inventoryEntry.Id }, new { data = inventoryEntry });
        }

        // MÉTODO PARA ACTUALIZAR UNA ENTRADA DE INVENTARIO
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InventoryEntry inventoryEntry)
        {
            var existingEntry = await _inventoryEntryService.GetByIdAsync(id);
            if (existingEntry == null)
                throw new AppException("INVENTORY ENTRY NOT FOUND", (int)HttpStatusCode.NotFound);

            inventoryEntry.Id = id;
            await _inventoryEntryService.UpdateAsync(inventoryEntry);
            return Ok(new { data = inventoryEntry });
        }

        // MÉTODO PARA ELIMINAR UNA ENTRADA DE INVENTARIO
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEntry = await _inventoryEntryService.GetByIdAsync(id);
            if (existingEntry == null)
                throw new AppException("INVENTORY ENTRY NOT FOUND", (int)HttpStatusCode.NotFound);

            await _inventoryEntryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
