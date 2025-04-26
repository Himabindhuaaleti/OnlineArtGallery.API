// File: Models/OrderDetail.cs
namespace OnlineArtGallery.API.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ArtProductId { get; set; }
        public ArtProduct? ArtProduct { get; set; }
    }
}