namespace ArtGallery.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } // Admin, Customer
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}