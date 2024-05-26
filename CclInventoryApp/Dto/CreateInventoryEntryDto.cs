using System.ComponentModel.DataAnnotations;

namespace CclInventoryApp.Dtos
{
    // DTO PARA CREAR UNA ENTRADA DE INVENTARIO
    public class CreateInventoryEntryDto
    {
        // IDENTIFICADOR DEL PRODUCTO
        [Required]
        public int ProductId { get; set; }

        // IDENTIFICADOR DEL USUARIO
        [Required]
        public int UserId { get; set; }

        // CANTIDAD DE PRODUCTO INGRESADO
        [Required]
        public int Quantity { get; set; }

        // MÉTODO DE INGRESO
        [Required]
        [StringLength(50)]
        public string Method { get; set; }
    }
}
