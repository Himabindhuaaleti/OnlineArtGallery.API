using ArtGallery.API.Models;
using ArtGallery.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.API.Data
{
    public class DataSeeder
    {
        public static void SeedData(ArtGalleryContext context)
        {
            if (!context.Users.Any())
            {
                SeedUsers(context);
            }

            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }

            if (!context.ArtWorks.Any())
            {
                SeedArtWorks(context);
            }

            context.SaveChanges();
        }

        private static void SeedUsers(ArtGalleryContext context)
        {
            AuthHelper.CreatePasswordHash("Admin123!", out byte[] adminPasswordHash, out byte[] adminPasswordSalt);
            AuthHelper.CreatePasswordHash("User123!", out byte[] userPasswordHash, out byte[] userPasswordSalt);

            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Email = "admin@artgallery.com",
                    FirstName = "Admin",
                    LastName = "User",
                    PasswordHash = adminPasswordHash,
                    PasswordSalt = adminPasswordSalt,
                    Role = "Admin",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Username = "john",
                    Email = "john@example.com",
                    FirstName = "John",
                    LastName = "Doe",
                    PasswordHash = userPasswordHash,
                    PasswordSalt = userPasswordSalt,
                    Role = "Customer",
                    CreatedAt = DateTime.Now
                }
            };

            context.Users.AddRange(users);
        }

        private static void SeedCategories(ArtGalleryContext context)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Paintings",
                    Description = "Original paintings in various media"
                },
                new Category
                {
                    Name = "Sculptures",
                    Description = "Three-dimensional art pieces"
                },
                new Category
                {
                    Name = "Photography",
                    Description = "Fine art photography prints"
                },
                new Category
                {
                    Name = "Digital Art",
                    Description = "Art created or presented using digital technology"
                },
                new Category
                {
                    Name = "Drawings",
                    Description = "Sketches, illustrations and drawing artworks"
                }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedArtWorks(ArtGalleryContext context)
        {
            var artWorks = new List<ArtWork>
            {
                new ArtWork
                {
                    Title = "Sunset Horizon",
                    Artist = "Maria Johnson",
                    Description = "A vibrant oil painting depicting a sunset over the ocean",
                    Price = 1200.00M,
                    ImageUrl = "https://placeholder.com/sunset-horizon.jpg",
                    Year = 2023,
                    Medium = "Oil on Canvas",
                    Dimensions = "24\" x 36\"",
                    CategoryId = 1,
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new ArtWork
                {
                    Title = "Abstract Emotions",
                    Artist = "David Chen",
                    Description = "An abstract expression of human emotions using bold colors and shapes",
                    Price = 950.00M,
                    ImageUrl = "https://placeholder.com/abstract-emotions.jpg",
                    Year = 2022,
                    Medium = "Acrylic on Canvas",
                    Dimensions = "30\" x 30\"",
                    CategoryId = 1,
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new ArtWork
                {
                    Title = "Bronze Guardian",
                    Artist = "Sophie Miller",
                    Description = "A bronze sculpture of a mythical guardian figure",
                    Price = 2500.00M,
                    ImageUrl = "https://placeholder.com/bronze-guardian.jpg",
                    Year = 2021,
                    Medium = "Bronze",
                    Dimensions = "18\" x 8\" x 6\"",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new ArtWork
                {
                    Title = "Urban Reflections",
                    Artist = "James Wilson",
                    Description = "Black and white photography capturing city reflections in rain",
                    Price = 450.00M,
                    ImageUrl = "https://placeholder.com/urban-reflections.jpg",
                    Year = 2023,
                    Medium = "Photography, Archival Print",
                    Dimensions = "16\" x 20\"",
                    CategoryId = 3,
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new ArtWork
                {
                    Title = "Digital Dreamscape",
                    Artist = "Alex Rivera",
                    Description = "A surreal digital landscape with floating islands and strange creatures",
                    Price = 350.00M,
                    ImageUrl = "https://placeholder.com/digital-dreamscape.jpg",
                    Year = 2024,
                    Medium = "Digital Art, Limited Print",
                    Dimensions = "24\" x 36\"",
                    CategoryId = 4,
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new ArtWork
                {
                    Title = "Charcoal Study",
                    Artist = "Emma Thompson",
                    Description = "A detailed charcoal drawing of a human figure",
                    Price = 600.00M,
                    ImageUrl = "https://placeholder.com/charcoal-study.jpg",
                    Year = 2022,
                    Medium = "Charcoal on Paper",
                    Dimensions = "18\" x 24\"",
                    CategoryId = 5,
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                }
            };

            context.ArtWorks.AddRange(artWorks);
        }
    }
}