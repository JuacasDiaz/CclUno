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
    public class InventoryEntriesController : ControllerBase
    {
        private readonly IInventoryEntryService _inventoryEntryService;

        // CONSTRUCTOR DEL CONTROLADOR
        public InventoryEntriesController(IInventoryEntryService inventoryEntryService)
        {
            _inventoryEntryService = inventoryEntryService;
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
        public async Task<IActionResult> Create([FromBody] InventoryEntry inventoryEntry)
        {
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
