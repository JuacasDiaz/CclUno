using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CclInventoryApp.Models
{
    /// <summary>
    /// Representa el historial de cambios en el stock de un producto.
    /// </summary>
    public class StockHistory
    {
        /// <summary>
        /// Identificador único del historial de cambios de stock.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto.
        /// </summary>
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Cambio en la cantidad del producto.
        /// </summary>
        [Required]
        public int QuantityChange { get; set; }

        /// <summary>
        /// Nueva cantidad del producto en stock.
        /// </summary>
        [Required]
        public int NewQuantity { get; set; }

        /// <summary>
        /// Tipo de cambio (entrada, salida).
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ChangeType { get; set; }

        /// <summary>
        /// Fecha del cambio.
        /// </summary>
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Identificador del usuario que hizo el cambio.
        /// </summary>
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
