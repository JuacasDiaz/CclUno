using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // INTERFAZ DEL SERVICIO DE STOCK
    public interface IStockService
    {
        // MÉTODO PARA OBTENER EL STOCK DE TODOS LOS PRODUCTOS
        Task<IEnumerable<Stock>> GetAllAsync();

        // MÉTODO PARA OBTENER EL STOCK DE UN PRODUCTO POR ID
        Task<Stock> GetByProductIdAsync(int productId);
    }
}
