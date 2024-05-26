using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // INTERFAZ DEL REPOSITORIO DE SALIDAS DE INVENTARIO
    public interface IInventoryExitRepository
    {
        // MÉTODO PARA OBTENER TODAS LAS SALIDAS DE INVENTARIO
        Task<IEnumerable<InventoryExit>> GetAllAsync();

        // MÉTODO PARA OBTENER UNA SALIDA DE INVENTARIO POR ID
        Task<InventoryExit> GetByIdAsync(int id);

        // MÉTODO PARA AÑADIR UNA NUEVA SALIDA DE INVENTARIO
        Task AddAsync(InventoryExit inventoryExit);

        // MÉTODO PARA ACTUALIZAR UNA SALIDA DE INVENTARIO
        Task UpdateAsync(InventoryExit inventoryExit);

        // MÉTODO PARA ELIMINAR UNA SALIDA DE INVENTARIO
        Task DeleteAsync(int id);
    }
}
