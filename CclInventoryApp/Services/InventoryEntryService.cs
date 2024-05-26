using CclInventoryApp.Models;
using CclInventoryApp.Repositories;
using CclInventoryApp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CclInventoryApp.Services
{
    // IMPLEMENTACIÓN DEL SERVICIO DE ENTRADAS DE INVENTARIO
    public class InventoryEntryService : IInventoryEntryService
    {
        private readonly IInventoryEntryRepository _inventoryEntryRepository;

        // CONSTRUCTOR DEL SERVICIO
        public InventoryEntryService(IInventoryEntryRepository inventoryEntryRepository)
        {
            _inventoryEntryRepository = inventoryEntryRepository;
        }

        // MÉTODO PARA OBTENER TODAS LAS ENTRADAS DE INVENTARIO
        public async Task<IEnumerable<InventoryEntryDto>> GetAllAsync()
        {
            var entries = await _inventoryEntryRepository.GetAllAsync();
            return entries.Select(entry => new InventoryEntryDto
            {
                Id = entry.Id,
                ProductId = entry.ProductId,
                UserId = entry.UserId,
                Quantity = entry.Quantity,
                Method = entry.Method,
                Date = entry.Date,
                CreatedAt = entry.CreatedAt,
                Product = new ProductDto
                {
                    Id = entry.Product.Id,
                    Name = entry.Product.Name,
                    Description = entry.Product.Description,
                    Price = entry.Product.Price,
                    CreatedAt = entry.Product.CreatedAt,
                    UpdatedAt = entry.Product.UpdatedAt
                },
                User = new UserDto
                {
                    Id = entry.User.Id,
                    Username = entry.User.Username,
                    CreatedAt = entry.User.CreatedAt,
                    UpdatedAt = entry.User.UpdatedAt
                }
            }).ToList();
        }

        // MÉTODO PARA OBTENER UNA ENTRADA DE INVENTARIO POR ID
        public async Task<InventoryEntryDto> GetByIdAsync(int id)
        {
            var entry = await _inventoryEntryRepository.GetByIdAsync(id);
            if (entry == null)
            {
                return null;
            }

            return new InventoryEntryDto
            {
                Id = entry.Id,
                ProductId = entry.ProductId,
                UserId = entry.UserId,
                Quantity = entry.Quantity,
                Method = entry.Method,
                Date = entry.Date,
                CreatedAt = entry.CreatedAt,
                Product = new ProductDto
                {
                    Id = entry.Product.Id,
                    Name = entry.Product.Name,
                    Description = entry.Product.Description,
                    Price = entry.Product.Price,
                    CreatedAt = entry.Product.CreatedAt,
                    UpdatedAt = entry.Product.UpdatedAt
                },
                User = new UserDto
                {
                    Id = entry.User.Id,
                    Username = entry.User.Username,
                    CreatedAt = entry.User.CreatedAt,
                    UpdatedAt = entry.User.UpdatedAt
                }
            };
        }

        // MÉTODO PARA AÑADIR UNA NUEVA ENTRADA DE INVENTARIO
        public async Task AddAsync(InventoryEntry inventoryEntry)
        {
            await _inventoryEntryRepository.AddAsync(inventoryEntry);
        }

        // MÉTODO PARA ACTUALIZAR UNA ENTRADA DE INVENTARIO
        public async Task UpdateAsync(InventoryEntry inventoryEntry)
        {
            await _inventoryEntryRepository.UpdateAsync(inventoryEntry);
        }

        // MÉTODO PARA ELIMINAR UNA ENTRADA DE INVENTARIO
        public async Task DeleteAsync(int id)
        {
            await _inventoryEntryRepository.DeleteAsync(id);
        }
    }
}
