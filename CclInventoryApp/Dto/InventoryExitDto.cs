using System;

namespace CclInventoryApp.Dtos
{
    // DTO PARA LA SALIDA DE INVENTARIO
    public class InventoryExitDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
}
