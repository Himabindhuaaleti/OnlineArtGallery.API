// File: DTOs/ArtProductDto.cs
namespace OnlineArtGallery.API.DTOs
{
    public class ArtProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}