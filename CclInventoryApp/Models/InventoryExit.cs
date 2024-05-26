using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CclInventoryApp.Models
{
    /// <summary>
    /// Representa una salida de mercancía en el inventario.
    /// </summary>
    public class InventoryExit
    {
        /// <summary>
        /// Identificador único de la salida de inventario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto.
        /// </summary>
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Identificador del usuario.
        /// </summary>
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Cantidad de producto saliente.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Razón de la salida (venta, avería, traslado).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Reason { get; set; }

        /// <summary>
        /// Fecha de la salida.
        /// </summary>
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Fecha de creación de la salida.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
