using CclInventoryApp.Dtos;
using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // INTERFAZ DEL SERVICIO DE SALIDAS DE INVENTARIO
    public interface IInventoryExitService
    {
        // MÉTODO PARA OBTENER TODAS LAS SALIDAS DE INVENTARIO
        Task<IEnumerable<InventoryExitDto>> GetAllAsync();

        // MÉTODO PARA OBTENER UNA SALIDA DE INVENTARIO POR ID
        Task<InventoryExitDto> GetByIdAsync(int id);

        // MÉTODO PARA AÑADIR UNA NUEVA SALIDA DE INVENTARIO
        Task AddAsync(InventoryExit inventoryExit);

        // MÉTODO PARA ACTUALIZAR UNA SALIDA DE INVENTARIO
        Task UpdateAsync(InventoryExit inventoryExit);

        // MÉTODO PARA ELIMINAR UNA SALIDA DE INVENTARIO
        Task DeleteAsync(int id);
    }
}
