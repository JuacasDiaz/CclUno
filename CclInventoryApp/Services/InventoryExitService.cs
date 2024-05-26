using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE SALIDAS DE INVENTARIO
    public class InventoryExitService : IInventoryExitService
    {
        private readonly IInventoryExitRepository _inventoryExitRepository;

        // CONSTRUCTOR DEL SERVICIO
        public InventoryExitService(IInventoryExitRepository inventoryExitRepository)
        {
            _inventoryExitRepository = inventoryExitRepository;
        }

        // MÉTODO PARA OBTENER TODAS LAS SALIDAS DE INVENTARIO
        public async Task<IEnumerable<InventoryExit>> GetAllAsync()
        {
            return await _inventoryExitRepository.GetAllAsync();
        }

        // MÉTODO PARA OBTENER UNA SALIDA DE INVENTARIO POR ID
        public async Task<InventoryExit> GetByIdAsync(int id)
        {
            return await _inventoryExitRepository.GetByIdAsync(id);
        }

        // MÉTODO PARA AÑADIR UNA NUEVA SALIDA DE INVENTARIO
        public async Task AddAsync(InventoryExit inventoryExit)
        {
            await _inventoryExitRepository.AddAsync(inventoryExit);
        }

        // MÉTODO PARA ACTUALIZAR UNA SALIDA DE INVENTARIO
        public async Task UpdateAsync(InventoryExit inventoryExit)
        {
            await _inventoryExitRepository.UpdateAsync(inventoryExit);
        }

        // MÉTODO PARA ELIMINAR UNA SALIDA DE INVENTARIO
        public async Task DeleteAsync(int id)
        {
            await _inventoryExitRepository.DeleteAsync(id);
        }
    }
}
