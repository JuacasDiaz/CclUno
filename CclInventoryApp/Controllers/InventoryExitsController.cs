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
    public class InventoryExitsController : ControllerBase
    {
        private readonly IInventoryExitService _inventoryExitService;

        // CONSTRUCTOR DEL CONTROLADOR
        public InventoryExitsController(IInventoryExitService inventoryExitService)
        {
            _inventoryExitService = inventoryExitService;
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
        public async Task<IActionResult> Create([FromBody] InventoryExit inventoryExit)
        {
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
