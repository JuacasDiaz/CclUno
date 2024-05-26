using CclInventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CclInventoryApp.Repositories
{
    // IMPLEMENTACIÓN DEL REPOSITORIO DE USUARIOS
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR DEL REPOSITORIO
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // MÉTODO PARA OBTENER TODOS LOS USUARIOS
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // MÉTODO PARA OBTENER UN USUARIO POR ID
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // MÉTODO PARA OBTENER UN USUARIO POR NOMBRE DE USUARIO
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        // MÉTODO PARA AÑADIR UN NUEVO USUARIO
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ACTUALIZAR UN USUARIO
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // MÉTODO PARA ELIMINAR UN USUARIO
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
