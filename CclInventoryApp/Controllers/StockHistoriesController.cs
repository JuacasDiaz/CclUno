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
    public class StockHistoriesController : ControllerBase
    {
        private readonly IStockHistoryService _stockHistoryService;

        // CONSTRUCTOR DEL CONTROLADOR
        public StockHistoriesController(IStockHistoryService stockHistoryService)
        {
            _stockHistoryService = stockHistoryService;
        }

        // MÉTODO PARA OBTENER TODO EL HISTORIAL DE STOCK
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stockHistories = await _stockHistoryService.GetAllAsync();
            return Ok(new { data = stockHistories });
        }

        // MÉTODO PARA OBTENER EL HISTORIAL DE STOCK POR ID DE PRODUCTO
        [HttpGet("by-product/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var stockHistories = await _stockHistoryService.GetByProductIdAsync(productId);
            return Ok(new { data = stockHistories });
        }
    }
}
