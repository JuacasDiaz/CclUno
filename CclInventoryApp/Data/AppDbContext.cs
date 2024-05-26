using Microsoft.EntityFrameworkCore;

namespace CclInventoryApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryEntry> InventoryEntries { get; set; }
        public DbSet<InventoryExit> InventoryExits { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de las relaciones y restricciones
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
                
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<InventoryEntry>()
                .HasOne(ie => ie.Product)
                .WithMany()
                .HasForeignKey(ie => ie.ProductId);

            modelBuilder.Entity<InventoryEntry>()
                .HasOne(ie => ie.User)
                .WithMany()
                .HasForeignKey(ie => ie.UserId);

            modelBuilder.Entity<InventoryExit>()
                .HasOne(ie => ie.Product)
                .WithMany()
                .HasForeignKey(ie => ie.ProductId);

            modelBuilder.Entity<InventoryExit>()
                .HasOne(ie => ie.User)
                .WithMany()
                .HasForeignKey(ie => ie.UserId);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithOne()
                .HasForeignKey<Stock>(s => s.ProductId);

            modelBuilder.Entity<StockHistory>()
                .HasOne(sh => sh.Product)
                .WithMany()
                .HasForeignKey(sh => sh.ProductId);

            modelBuilder.Entity<StockHistory>()
                .HasOne(sh => sh.User)
                .WithMany()
                .HasForeignKey(sh => sh.UserId);
        }
    }
}
