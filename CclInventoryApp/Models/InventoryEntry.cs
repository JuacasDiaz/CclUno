using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CclInventoryApp.Models
{
    /// <summary>
    /// Representa una entrada de mercancía en el inventario.
    /// </summary>
    public class InventoryEntry
    {
        /// <summary>
        /// Identificador único de la entrada de inventario.
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
        /// Cantidad de producto ingresada.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Método de ingreso (compra, traslado).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Method { get; set; }

        /// <summary>
        /// Fecha de la entrada.
        /// </summary>
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Fecha de creación de la entrada.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
