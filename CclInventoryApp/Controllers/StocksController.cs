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
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        // CONSTRUCTOR DEL CONTROLADOR
        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // MÉTODO PARA OBTENER EL STOCK DE TODOS LOS PRODUCTOS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(new { data = stocks });
        }

        // MÉTODO PARA OBTENER EL STOCK DE UN PRODUCTO POR ID
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var stock = await _stockService.GetByProductIdAsync(productId);
            if (stock == null)
                throw new AppException("STOCK NOT FOUND", (int)HttpStatusCode.NotFound);

            return Ok(new { data = stock });
        }
    }
}
