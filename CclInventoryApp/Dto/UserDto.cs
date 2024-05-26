namespace CclInventoryApp.Dtos
{
    // DTO PARA USUARIO
    public class UserDto
    {
        // IDENTIFICADOR DEL USUARIO
        public int Id { get; set; }

        // NOMBRE DE USUARIO
        public string Username { get; set; }

        // FECHA DE CREACIÓN DEL USUARIO
        public DateTime CreatedAt { get; set; }

        // FECHA DE ACTUALIZACIÓN DEL USUARIO
        public DateTime UpdatedAt { get; set; }
    }
}
