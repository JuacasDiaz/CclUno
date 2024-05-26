using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE STOCK
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        // CONSTRUCTOR DEL SERVICIO
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        // MÉTODO PARA OBTENER EL STOCK DE TODOS LOS PRODUCTOS
        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _stockRepository.GetAllAsync();
        }

        // MÉTODO PARA OBTENER EL STOCK DE UN PRODUCTO POR ID
        public async Task<Stock> GetByProductIdAsync(int productId)
        {
            return await _stockRepository.GetByProductIdAsync(productId);
        }
    }
}
