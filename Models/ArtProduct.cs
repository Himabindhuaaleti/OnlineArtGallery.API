// File: Models/ArtProduct.cs
namespace OnlineArtGallery.API.Models
{
    public class ArtProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

    }
}