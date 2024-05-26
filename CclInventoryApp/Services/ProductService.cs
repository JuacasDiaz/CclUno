using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        // CONSTRUCTOR DEL SERVICIO
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // MÉTODO PARA OBTENER TODOS LOS PRODUCTOS
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // MÉTODO PARA OBTENER UN PRODUCTO POR ID
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // MÉTODO PARA OBTENER PRODUCTOS FILTRADOS POR FECHAS DE INGRESO
        public async Task<IEnumerable<Product>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _productRepository.GetByDateRangeAsync(startDate, endDate);
        }

        // MÉTODO PARA CREAR UN NUEVO PRODUCTO
        public async Task<Product> AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            return product;
        }

        // MÉTODO PARA ACTUALIZAR UN PRODUCTO
        public async Task<Product> UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return product;
        }

        // MÉTODO PARA ELIMINAR UN PRODUCTO
        public async Task<bool> DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
            return true;
        }
    }
}
