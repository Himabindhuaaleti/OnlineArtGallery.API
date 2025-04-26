
// File: Controllers/ArtController.cs
using Microsoft.AspNetCore.Mvc;
using OnlineArtGallery.API.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineArtGallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtController : ControllerBase
    {
        private readonly GalleryContext _context;

        public ArtController(GalleryContext context)
        {
            _context = context;
        }

        [HttpGet("category/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var products = _context.ArtProducts.Where(p => p.Category == category).ToList();
            return Ok(products);
        }

        [HttpPost("by-ids")]
        public IActionResult GetByIds([FromBody] List<int> ids)
        {
            var products = _context.ArtProducts.Where(p => ids.Contains(p.Id)).ToList();
            return Ok(products);
        }
    }
}
