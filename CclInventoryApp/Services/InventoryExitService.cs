using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CclInventoryApp.Dtos;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE SALIDAS DE INVENTARIO
    public class InventoryExitService : IInventoryExitService
    {
        private readonly IInventoryExitRepository _inventoryExitRepository;

        // CONSTRUCTOR DEL SERVICIO
        public InventoryExitService(IInventoryExitRepository inventoryExitRepository)
        {
            _inventoryExitRepository = inventoryExitRepository;
        }

        // MÉTODO PARA OBTENER TODAS LAS SALIDAS DE INVENTARIO
        public async Task<IEnumerable<InventoryExitDto>> GetAllAsync()
        {
            var exits = await _inventoryExitRepository.GetAllAsync();
            return exits.Select(exit => new InventoryExitDto
            {
                Id = exit.Id,
                ProductId = exit.ProductId,
                UserId = exit.UserId,
                Quantity = exit.Quantity,
                Reason = exit.Reason,
                Date = exit.Date,
                CreatedAt = exit.CreatedAt,
                Product = new ProductDto
                {
                    Id = exit.Product.Id,
                    Name = exit.Product.Name,
                    Description = exit.Product.Description,
                    Price = exit.Product.Price,
                    CreatedAt = exit.Product.CreatedAt,
                    UpdatedAt = exit.Product.UpdatedAt
                },
                User = new UserDto
                {
                    Id = exit.User.Id,
                    Username = exit.User.Username,
                    CreatedAt = exit.User.CreatedAt,
                    UpdatedAt = exit.User.UpdatedAt
                }
            }).ToList();
        }

        // MÉTODO PARA OBTENER UNA SALIDA DE INVENTARIO POR ID
        public async Task<InventoryExitDto> GetByIdAsync(int id)
        {
            var exit = await _inventoryExitRepository.GetByIdAsync(id);
            if (exit == null)
            {
                return null;
            }

            return new InventoryExitDto
            {
                Id = exit.Id,
                ProductId = exit.ProductId,
                UserId = exit.UserId,
                Quantity = exit.Quantity,
                Reason = exit.Reason,
                Date = exit.Date,
                CreatedAt = exit.CreatedAt,
                Product = new ProductDto
                {
                    Id = exit.Product.Id,
                    Name = exit.Product.Name,
                    Description = exit.Product.Description,
                    Price = exit.Product.Price,
                    CreatedAt = exit.Product.CreatedAt,
                    UpdatedAt = exit.Product.UpdatedAt
                },
                User = new UserDto
                {
                    Id = exit.User.Id,
                    Username = exit.User.Username,
                    CreatedAt = exit.User.CreatedAt,
                    UpdatedAt = exit.User.UpdatedAt
                }
            };
        }

        // MÉTODO PARA AÑADIR UNA NUEVA SALIDA DE INVENTARIO
        public async Task AddAsync(InventoryExit inventoryExit)
        {
            await _inventoryExitRepository.AddAsync(inventoryExit);
        }

        // MÉTODO PARA ACTUALIZAR UNA SALIDA DE INVENTARIO
        public async Task UpdateAsync(InventoryExit inventoryExit)
        {
            await _inventoryExitRepository.UpdateAsync(inventoryExit);
        }

        // MÉTODO PARA ELIMINAR UNA SALIDA DE INVENTARIO
        public async Task DeleteAsync(int id)
        {
            await _inventoryExitRepository.DeleteAsync(id);
        }
    }
}
