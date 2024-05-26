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
            return await _context.InventoryEntries
                .Include(ie => ie.Product) // Incluir Producto
                .Include(ie => ie.User) // Incluir Usuario
                .ToListAsync();
        }

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        public async Task<InventoryEntry> GetByIdAsync(int id)
        {
            return await _context.InventoryEntries
                .Include(ie => ie.Product) // Incluir Producto
                .Include(ie => ie.User) // Incluir Usuario
                .FirstOrDefaultAsync(ie => ie.Id == id);
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
            var inventoryEntry = await _context.InventoryEntries.FindAsync(id);
            if (inventoryEntry != null)
            {
                _context.InventoryEntries.Remove(inventoryEntry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
