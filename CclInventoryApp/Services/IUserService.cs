using CclInventoryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // INTERFAZ DEL SERVICIO DE USUARIOS
    public interface IUserService
    {
        // MÉTODO PARA OBTENER TODOS LOS USUARIOS
        Task<IEnumerable<User>> GetAllAsync();

        // MÉTODO PARA OBTENER UN USUARIO POR ID
        Task<User> GetByIdAsync(int id);

        // MÉTODO PARA AÑADIR UN NUEVO USUARIO
        Task AddAsync(User user);

        // MÉTODO PARA ACTUALIZAR UN USUARIO
        Task UpdateAsync(User user);

        // MÉTODO PARA ELIMINAR UN USUARIO
        Task DeleteAsync(int id);
    }
}
