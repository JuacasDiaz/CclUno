using CclInventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // IMPLEMENTACIÓN DEL REPOSITORIO DE SALIDAS DE INVENTARIO
    public class InventoryExitRepository : IInventoryExitRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR DEL REPOSITORIO
        public InventoryExitRepository(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PARA OBTENER TODAS LAS SALIDAS DE INVENTARIO
        public async Task<IEnumerable<InventoryExit>> GetAllAsync()
        {
            return await _context.InventoryExits.ToListAsync();
        }

        // MÉTODO PARA OBTENER UNA SALIDA DE INVENTARIO POR ID
        public async Task<InventoryExit> GetByIdAsync(int id)
        {
            return await _context.InventoryExits.FindAsync(id);
        }

        // MÉTODO PARA AÑADIR UNA NUEVA SALIDA DE INVENTARIO
        public async Task AddAsync(InventoryExit inventoryExit)
        {
            await _context.InventoryExits.AddAsync(inventoryExit);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ACTUALIZAR UNA SALIDA DE INVENTARIO
        public async Task UpdateAsync(InventoryExit inventoryExit)
        {
            _context.InventoryExits.Update(inventoryExit);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ELIMINAR UNA SALIDA DE INVENTARIO
        public async Task DeleteAsync(int id)
        {
            var exit = await _context.InventoryExits.FindAsync(id);
            if (exit != null)
            {
                _context.InventoryExits.Remove(exit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
