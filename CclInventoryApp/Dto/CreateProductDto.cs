using System.ComponentModel.DataAnnotations;

namespace CclInventoryApp.Dtos
{
    // DTO PARA CREAR UN PRODUCTO
    public class CreateProductDto
    {
        // NOMBRE DEL PRODUCTO
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // DESCRIPCIÓN DEL PRODUCTO
        public string Description { get; set; }

        // PRECIO DEL PRODUCTO
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
