using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // INTERFAZ DEL REPOSITORIO DE HISTORIAL DE STOCK
    public interface IStockHistoryRepository
    {
        // MÉTODO PARA OBTENER TODO EL HISTORIAL DE STOCK
        Task<IEnumerable<StockHistory>> GetAllAsync();

        // MÉTODO PARA OBTENER EL HISTORIAL DE STOCK POR ID DE PRODUCTO
        Task<IEnumerable<StockHistory>> GetByProductIdAsync(int productId);
    }
}
