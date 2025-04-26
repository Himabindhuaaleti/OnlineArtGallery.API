using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.API.Models;

namespace OnlineArtGallery.API.Data
{
    public class GalleryContext : DbContext
    {
        public GalleryContext(DbContextOptions<GalleryContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<ArtProduct> ArtProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}