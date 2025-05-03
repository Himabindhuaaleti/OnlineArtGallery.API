namespace ArtGallery.API.DTOs
{
    public class ArtWorkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public string Medium { get; set; }
        public string Dimensions { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class ArtWorkCreateDto
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public string Medium { get; set; }
        public string Dimensions { get; set; }
        public int CategoryId { get; set; }
    }
}