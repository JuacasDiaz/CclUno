using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE ENTRADAS DE INVENTARIO
    public class InventoryEntryService : IInventoryEntryService
    {
        private readonly IInventoryEntryRepository _inventoryEntryRepository;

        // CONSTRUCTOR DEL SERVICIO
        public InventoryEntryService(IInventoryEntryRepository inventoryEntryRepository)
        {
            _inventoryEntryRepository = inventoryEntryRepository;
        }

        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS DE INVENTARIO
        public async Task<IEnumerable<InventoryEntry>> GetAllAsync()
        {
            return await _inventoryEntryRepository.GetAllAsync();
        }

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        public async Task<InventoryEntry> GetByIdAsync(int id)
        {
            return await _inventoryEntryRepository.GetByIdAsync(id);
        }

        // MÉTODO PARA AÑADIR UNA NUEVA ENTRADA DE INVENTARIO
        public async Task AddAsync(InventoryEntry inventoryEntry)
        {
            await _inventoryEntryRepository.AddAsync(inventoryEntry);
        }

        // MÉTODO PARA ACTUALIZAR UNA ENTRADA DE INVENTARIO
        public async Task UpdateAsync(InventoryEntry inventoryEntry)
        {
            await _inventoryEntryRepository.UpdateAsync(inventoryEntry);
        }

        // MÉTODO PARA ELIMINAR UNA ENTRADA DE INVENTARIO
        public async Task DeleteAsync(int id)
        {
            await _inventoryEntryRepository.DeleteAsync(id);
        }
    }
}
