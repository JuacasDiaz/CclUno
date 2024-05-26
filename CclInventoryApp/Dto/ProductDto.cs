namespace CclInventoryApp.Dtos
{
    // DTO PARA PRODUCTO
    public class ProductDto
    {
        // IDENTIFICADOR DEL PRODUCTO
        public int Id { get; set; }

        // NOMBRE DEL PRODUCTO
        public string Name { get; set; }

        // DESCRIPCIÓN DEL PRODUCTO
        public string Description { get; set; }

        // PRECIO DEL PRODUCTO
        public decimal Price { get; set; }

        // FECHA DE CREACIÓN DEL PRODUCTO
        public DateTime CreatedAt { get; set; }

        // FECHA DE ACTUALIZACIÓN DEL PRODUCTO
        public DateTime UpdatedAt { get; set; }
    }
}
