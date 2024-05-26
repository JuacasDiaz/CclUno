using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE PRODUCTOS
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

        // MÉTODO PARA AÑADIR UN NUEVO PRODUCTO
        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        // MÉTODO PARA ACTUALIZAR UN PRODUCTO
        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        // MÉTODO PARA ELIMINAR UN PRODUCTO
        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
