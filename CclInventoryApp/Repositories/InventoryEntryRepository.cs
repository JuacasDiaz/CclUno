using CclInventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // IMPLEMENTACIÓN DEL REPOSITORIO DE ENTRADAS DE INVENTARIO
    public class InventoryEntryRepository : IInventoryEntryRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR DEL REPOSITORIO
        public InventoryEntryRepository(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS DE INVENTARIO
        public async Task<IEnumerable<InventoryEntry>> GetAllAsync()
        {
            return await _context.InventoryEntries.ToListAsync();
        }

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        public async Task<InventoryEntry> GetByIdAsync(int id)
        {
            return await _context.InventoryEntries.FindAsync(id);
        }

        // MÉTODO PARA AÑADIR UNA NUEVA ENTRADA DE INVENTARIO
        public async Task AddAsync(InventoryEntry inventoryEntry)
        {
            await _context.InventoryEntries.AddAsync(inventoryEntry);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ACTUALIZAR UNA ENTRADA DE INVENTARIO
        public async Task UpdateAsync(InventoryEntry inventoryEntry)
        {
            _context.InventoryEntries.Update(inventoryEntry);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ELIMINAR UNA ENTRADA DE INVENTARIO
        public async Task DeleteAsync(int id)
        {
            var entry = await _context.InventoryEntries.FindAsync(id);
            if (entry != null)
            {
                _context.InventoryEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
