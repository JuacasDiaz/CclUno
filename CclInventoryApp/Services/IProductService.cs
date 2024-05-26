using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // INTERFAZ DEL SERVICIO DE PRODUCTOS
    public interface IProductService
    {
        // MÉTODO PARA OBTENER TODOS LOS PRODUCTOS
        Task<IEnumerable<Product>> GetAllAsync();

        // MÉTODO PARA OBTENER UN PRODUCTO POR ID
        Task<Product> GetByIdAsync(int id);

        // MÉTODO PARA AÑADIR UN NUEVO PRODUCTO
        Task AddAsync(Product product);

        // MÉTODO PARA ACTUALIZAR UN PRODUCTO
        Task UpdateAsync(Product product);

        // MÉTODO PARA ELIMINAR UN PRODUCTO
        Task DeleteAsync(int id);
    }
}
