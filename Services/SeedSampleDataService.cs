using OnlineArtGallery.API.Data;
using OnlineArtGallery.API.Models;
using BCrypt.Net;


public class SeedDataService
{
    private readonly GalleryContext _context;

    public SeedDataService(GalleryContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        SeedUsers();
        SeedArtProducts();
        SeedOrders();
        _context.SaveChanges();
    }

    private void SeedUsers()
    {
        if (!_context.Users.Any())
        {
            _context.Users.AddRange(
                new User { Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), Role = "Admin" },
                new User { Username = "alice", PasswordHash = BCrypt.Net.BCrypt.HashPassword("alicepass"), Role = "Customer" },
                new User { Username = "bob", PasswordHash = BCrypt.Net.BCrypt.HashPassword("bobpass"), Role = "Customer" }
            );
        }
    }

    private void SeedArtProducts()
    {
        if (!_context.ArtProducts.Any())
        {
            _context.ArtProducts.AddRange(
                new ArtProduct
                {
                    Name = "Sunset Horizon",
                    Category = "Painting",
                    Description = "A colorful sunset over mountains.",
                    Price = 800,
                    ImageUrl = "https://example.com/images/sunset.jpg"
                },
                new ArtProduct
                {
                    Name = "Modern Abstract",
                    Category = "Digital Art",
                    Description = "A chaotic but aesthetic digital abstraction.",
                    Price = 1200,
                    ImageUrl = "https://example.com/images/abstract.jpg"
                },
                new ArtProduct
                {
                    Name = "Marble Sculpture",
                    Category = "Sculpture",
                    Description = "A clean marble sculpture of a dancer.",
                    Price = 3000,
                    ImageUrl = "https://example.com/images/sculpture.jpg"
                }
            );
        }
    }

    private void SeedOrders()
    {
        if (!_context.Orders.Any())
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == "alice");
            var product1 = _context.ArtProducts.FirstOrDefault(p => p.Name == "Sunset Horizon");
            var product2 = _context.ArtProducts.FirstOrDefault(p => p.Name == "Marble Sculpture");

            if (user != null && product1 != null && product2 != null)
            {
                _context.Orders.Add(new Order
                {
                    UserId = user.Id,
                    OrderDate = DateTime.Now.AddDays(-5),
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail { ArtProductId = product1.Id, Quantity = 1 },
                        new OrderDetail { ArtProductId = product2.Id, Quantity = 1 }
                    }
                });
            }
        }
    }
}
