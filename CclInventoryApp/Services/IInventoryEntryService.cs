using CclInventoryApp.Dtos;
using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // INTERFAZ DEL SERVICIO DE ENTRADAS DE INVENTARIO
    public interface IInventoryEntryService
    {
        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS DE INVENTARIO
        Task<IEnumerable<InventoryEntryDto>> GetAllAsync();

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        Task<InventoryEntryDto> GetByIdAsync(int id);

        // MÉTODO PARA AÑADIR UNA NUEVA ENTRADA DE INVENTARIO
        Task AddAsync(InventoryEntry inventoryEntry);

        // MÉTODO PARA ACTUALIZAR UNA ENTRADA DE INVENTARIO
        Task UpdateAsync(InventoryEntry inventoryEntry);

        // MÉTODO PARA ELIMINAR UNA ENTRADA DE INVENTARIO
        Task DeleteAsync(int id);
    }
}
