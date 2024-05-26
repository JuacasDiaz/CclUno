using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CclInventoryApp.Models
{
    /// <summary>
    /// Representa el stock de un producto en el inventario.
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Identificador del producto.
        /// </summary>
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Cantidad actual del producto en stock.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Fecha de la última actualización del stock.
        /// </summary>
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public virtual Product Product { get; set; }
    }
}
