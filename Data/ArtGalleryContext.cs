using ArtGallery.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.API.Data
{
    public class ArtGalleryContext : DbContext
    {
        public ArtGalleryContext(DbContextOptions<ArtGalleryContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArtWork> ArtWorks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<ArtWork>()
                .HasOne(a => a.Category)
                .WithMany(c => c.ArtWorks)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.ArtWork)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(oi => oi.ArtWorkId);
        }
    }
}