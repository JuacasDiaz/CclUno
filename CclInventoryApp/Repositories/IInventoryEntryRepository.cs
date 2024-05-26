using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // INTERFAZ DEL REPOSITORIO DE ENTRADAS DE INVENTARIO
    public interface IInventoryEntryRepository
    {
        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS DE INVENTARIO
        Task<IEnumerable<InventoryEntry>> GetAllAsync();

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        Task<InventoryEntry> GetByIdAsync(int id);

        // MÉTODO PARA AÑADIR UNA NUEVA ENTRADA DE INVENTARIO
        Task AddAsync(InventoryEntry inventoryEntry);

        // MÉTODO PARA ACTUALIZAR UNA ENTRADA DE INVENTARIO
        Task UpdateAsync(InventoryEntry inventoryEntry);

        // MÉTODO PARA ELIMINAR UNA ENTRADA DE INVENTARIO
        Task DeleteAsync(int id);
    }
}
