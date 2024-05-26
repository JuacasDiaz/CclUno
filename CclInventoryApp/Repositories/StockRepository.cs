using CclInventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // IMPLEMENTACIÓN DEL REPOSITORIO DE STOCK
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR DEL REPOSITORIO
        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PARA OBTENER EL STOCK DE TODOS LOS PRODUCTOS
        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        // MÉTODO PARA OBTENER EL STOCK DE UN PRODUCTO POR ID
        public async Task<Stock> GetByProductIdAsync(int productId)
        {
            return await _context.Stocks.FindAsync(productId);
        }
    }
}
