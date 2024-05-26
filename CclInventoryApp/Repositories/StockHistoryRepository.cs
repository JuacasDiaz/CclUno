using CclInventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // IMPLEMENTACIÓN DEL REPOSITORIO DE HISTORIAL DE STOCK
    public class StockHistoryRepository : IStockHistoryRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR DEL REPOSITORIO
        public StockHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PARA OBTENER TODO EL HISTORIAL DE STOCK
        public async Task<IEnumerable<StockHistory>> GetAllAsync()
        {
            return await _context.StockHistories.ToListAsync();
        }

        // MÉTODO PARA OBTENER EL HISTORIAL DE STOCK POR ID DE PRODUCTO
        public async Task<IEnumerable<StockHistory>> GetByProductIdAsync(int productId)
        {
            return await _context.StockHistories
                .Where(sh => sh.ProductId == productId)
                .ToListAsync();
        }
    }
}
