using CclInventoryApp.Exceptions;
using CclInventoryApp.Models;
using CclInventoryApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CclInventoryApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        // CONSTRUCTOR DEL CONTROLADOR
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // MÉTODO PARA OBTENER TODOS LOS USUARIOS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(new { data = users });
        }

        // MÉTODO PARA OBTENER UN USUARIO POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                throw new AppException("USER NOT FOUND", (int)HttpStatusCode.NotFound);

            return Ok(new { data = user });
        }

        // MÉTODO PARA CREAR UN NUEVO USUARIO
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, new { data = user });
        }

        // MÉTODO PARA ACTUALIZAR UN USUARIO
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
                throw new AppException("USER NOT FOUND", (int)HttpStatusCode.NotFound);

            user.Id = id;
            await _userService.UpdateAsync(user);
            return Ok(new { data = user });
        }

        // MÉTODO PARA ELIMINAR UN USUARIO
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
                throw new AppException("USER NOT FOUND", (int)HttpStatusCode.NotFound);

            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
