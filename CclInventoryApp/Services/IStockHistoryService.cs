using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // INTERFAZ DEL SERVICIO DE HISTORIAL DE STOCK
    public interface IStockHistoryService
    {
        // MÉTODO PARA OBTENER TODO EL HISTORIAL DE STOCK
        Task<IEnumerable<StockHistory>> GetAllAsync();

        // MÉTODO PARA OBTENER EL HISTORIAL DE STOCK POR ID DE PRODUCTO
        Task<IEnumerable<StockHistory>> GetByProductIdAsync(int productId);
    }
}
