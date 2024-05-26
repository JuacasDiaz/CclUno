using System;

namespace CclInventoryApp.Dtos
{
    // DTO PARA ENTRADA DE INVENTARIO
    public class InventoryEntryDto
    {
        // IDENTIFICADOR DE LA ENTRADA DE INVENTARIO
        public int Id { get; set; }

        // IDENTIFICADOR DEL PRODUCTO
        public int ProductId { get; set; }

        // IDENTIFICADOR DEL USUARIO
        public int UserId { get; set; }

        // CANTIDAD DE PRODUCTO INGRESADO
        public int Quantity { get; set; }

        // MÉTODO DE INGRESO
        public string Method { get; set; }

        // FECHA DE LA ENTRADA
        public DateTime Date { get; set; }

        // FECHA DE CREACIÓN DE LA ENTRADA
        public DateTime CreatedAt { get; set; }

        // INFORMACIÓN DEL PRODUCTO
        public ProductDto Product { get; set; }

        // INFORMACIÓN DEL USUARIO
        public UserDto User { get; set; }
    }
}
