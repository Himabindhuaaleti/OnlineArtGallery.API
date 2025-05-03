namespace ArtGallery.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Pending, Completed, Cancelled
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string InvoiceNumber { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}