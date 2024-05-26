using System;
using System.ComponentModel.DataAnnotations;

namespace CclInventoryApp.Dtos
{
    // DTO PARA CREAR UNA SALIDA DE INVENTARIO
    public class CreateInventoryExitDto
    {
        // IDENTIFICADOR DEL PRODUCTO
        [Required]
        public int ProductId { get; set; }

        // IDENTIFICADOR DEL USUARIO
        [Required]
        public int UserId { get; set; }

        // CANTIDAD DE PRODUCTO SALIENTE
        [Required]
        public int Quantity { get; set; }

        // RAZÓN DE LA SALIDA (VENTA, AVERÍA, TRASLADO)
        [Required]
        [StringLength(50)]
        public string Reason { get; set; }
    }
}
