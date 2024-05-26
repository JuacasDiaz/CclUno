using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using CclInventoryApp.Utilities; // Importar el espacio de nombres correcto
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE USUARIOS
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // CONSTRUCTOR DEL SERVICIO
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // MÉTODO PARA OBTENER TODOS LOS USUARIOS
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // MÉTODO PARA OBTENER UN USUARIO POR ID
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // MÉTODO PARA OBTENER UN USUARIO POR NOMBRE DE USUARIO
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        // MÉTODO PARA AÑADIR UN NUEVO USUARIO
        public async Task AddAsync(User user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password);
            await _userRepository.AddAsync(user);
        }

        // MÉTODO PARA ACTUALIZAR UN USUARIO
        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        // MÉTODO PARA ELIMINAR UN USUARIO
        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
