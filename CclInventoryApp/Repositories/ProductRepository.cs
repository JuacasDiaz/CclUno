using CclInventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // IMPLEMENTACIÓN DEL REPOSITORIO DE PRODUCTOS
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR DEL REPOSITORIO
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PARA OBTENER TODOS LOS PRODUCTOS
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // MÉTODO PARA OBTENER UN PRODUCTO POR ID
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        // MÉTODO PARA AÑADIR UN NUEVO PRODUCTO
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ACTUALIZAR UN PRODUCTO
        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).State = EntityState.Detached;
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ELIMINAR UN PRODUCTO
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        // MÉTODO PARA OBTENER PRODUCTOS FILTRADOS POR FECHAS DE INGRESO
        public async Task<IEnumerable<Product>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Convertir las fechas a UTC antes de la consulta
            startDate = startDate.ToUniversalTime();
            endDate = endDate.ToUniversalTime();

            return await _context.Products
                .Where(p => p.CreatedAt >= startDate && p.CreatedAt <= endDate)
                .ToListAsync();
        }
    }
}
