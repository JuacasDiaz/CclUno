using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE HISTORIAL DE STOCK
    public class StockHistoryService : IStockHistoryService
    {
        private readonly IStockHistoryRepository _stockHistoryRepository;

        // CONSTRUCTOR DEL SERVICIO
        public StockHistoryService(IStockHistoryRepository stockHistoryRepository)
        {
            _stockHistoryRepository = stockHistoryRepository;
        }

        // MÉTODO PARA OBTENER TODO EL HISTORIAL DE STOCK
        public async Task<IEnumerable<StockHistory>> GetAllAsync()
        {
            return await _stockHistoryRepository.GetAllAsync();
        }

        // MÉTODO PARA OBTENER EL HISTORIAL DE STOCK POR ID DE PRODUCTO
        public async Task<IEnumerable<StockHistory>> GetByProductIdAsync(int productId)
        {
            return await _stockHistoryRepository.GetByProductIdAsync(productId);
        }
    }
}
