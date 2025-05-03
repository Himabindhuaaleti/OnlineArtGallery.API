using ArtGallery.API.Data;
using ArtGallery.API.DTOs;
using ArtGallery.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtWorkController : ControllerBase
    {
        private readonly ArtGalleryContext _context;

        public ArtWorkController(ArtGalleryContext context)
        {
            _context = context;
        }

        // GET: api/ArtWork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtWorkDto>>> GetArtWorks()
        {
            var artWorks = await _context.ArtWorks
                .Include(a => a.Category)
                .Select(a => new ArtWorkDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    Description = a.Description,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    Year = a.Year,
                    Medium = a.Medium,
                    Dimensions = a.Dimensions,
                    CategoryId = a.CategoryId,
                    CategoryName = a.Category.Name,
                    IsAvailable = a.IsAvailable
                })
                .ToListAsync();

            return Ok(artWorks);
        }

        // GET: api/ArtWork/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtWorkDto>> GetArtWork(int id)
        {
            var artWork = await _context.ArtWorks
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (artWork == null)
            {
                return NotFound();
            }

            var artWorkDto = new ArtWorkDto
            {
                Id = artWork.Id,
                Title = artWork.Title,
                Artist = artWork.Artist,
                Description = artWork.Description,
                Price = artWork.Price,
                ImageUrl = artWork.ImageUrl,
                Year = artWork.Year,
                Medium = artWork.Medium,
                Dimensions = artWork.Dimensions,
                CategoryId = artWork.CategoryId,
                CategoryName = artWork.Category.Name,
                IsAvailable = artWork.IsAvailable
            };

            return Ok(artWorkDto);
        }

        // GET: api/ArtWork/category/1
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ArtWorkDto>>> GetArtWorksByCategory(int categoryId)
        {
            var artWorks = await _context.ArtWorks
                .Include(a => a.Category)
                .Where(a => a.CategoryId == categoryId)
                .Select(a => new ArtWorkDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    Description = a.Description,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    Year = a.Year,
                    Medium = a.Medium,
                    Dimensions = a.Dimensions,
                    CategoryId = a.CategoryId,
                    CategoryName = a.Category.Name,
                    IsAvailable = a.IsAvailable
                })
                .ToListAsync();

            return Ok(artWorks);
        }

        // POST: api/ArtWork/batch
        [HttpPost("batch")]
        public async Task<ActionResult<IEnumerable<ArtWorkDto>>> GetArtWorksBatch([FromBody] List<int> ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest("No ids provided");

            var artWorks = await _context.ArtWorks
                .Include(a => a.Category)
                .Where(a => ids.Contains(a.Id))
                .Select(a => new ArtWorkDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Artist = a.Artist,
                    Description = a.Description,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    Year = a.Year,
                    Medium = a.Medium,
                    Dimensions = a.Dimensions,
                    CategoryId = a.CategoryId,
                    CategoryName = a.Category.Name,
                    IsAvailable = a.IsAvailable
                })
                .ToListAsync();

            if (!artWorks.Any())
                return NotFound("No art works found with the provided ids");

            return Ok(artWorks);
        }

        // POST: api/ArtWork
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ArtWorkDto>> CreateArtWork(ArtWorkCreateDto artWorkCreateDto)
        {
            var category = await _context.Categories.FindAsync(artWorkCreateDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Category not found");
            }

            var artWork = new ArtWork
            {
                Title = artWorkCreateDto.Title,
                Artist = artWorkCreateDto.Artist,
                Description = artWorkCreateDto.Description,
                Price = artWorkCreateDto.Price,
                ImageUrl = artWorkCreateDto.ImageUrl,
                Year = artWorkCreateDto.Year,
                Medium = artWorkCreateDto.Medium,
                Dimensions = artWorkCreateDto.Dimensions,
                CategoryId = artWorkCreateDto.CategoryId,
                IsAvailable = true,
                CreatedAt = DateTime.Now
            };

            _context.ArtWorks.Add(artWork);
            await _context.SaveChangesAsync();

            var artWorkDto = new ArtWorkDto
            {
                Id = artWork.Id,
                Title = artWork.Title,
                Artist = artWork.Artist,
                Description = artWork.Description,
                Price = artWork.Price,
                ImageUrl = artWork.ImageUrl,
                Year = artWork.Year,
                Medium = artWork.Medium,
                Dimensions = artWork.Dimensions,
                CategoryId = artWork.CategoryId,
                CategoryName = category.Name,
                IsAvailable = artWork.IsAvailable
            };

            return CreatedAtAction(nameof(GetArtWork), new { id = artWork.Id }, artWorkDto);
        }

        // PUT: api/ArtWork/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateArtWork(int id, ArtWorkCreateDto artWorkCreateDto)
        {
            var artWork = await _context.ArtWorks.FindAsync(id);
            if (artWork == null)
            {
                return NotFound();
            }

            artWork.Title = artWorkCreateDto.Title;
            artWork.Artist = artWorkCreateDto.Artist;
            artWork.Description = artWorkCreateDto.Description;
            artWork.Price = artWorkCreateDto.Price;
            artWork.ImageUrl = artWorkCreateDto.ImageUrl;
            artWork.Year = artWorkCreateDto.Year;
            artWork.Medium = artWorkCreateDto.Medium;
            artWork.Dimensions = artWorkCreateDto.Dimensions;
            artWork.CategoryId = artWorkCreateDto.CategoryId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ArtWork/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteArtWork(int id)
        {
            var artWork = await _context.ArtWorks.FindAsync(id);
            if (artWork == null)
            {
                return NotFound();
            }

            // Check if the artwork is part of any order
            var isInOrder = await _context.OrderItems.AnyAsync(oi => oi.ArtWorkId == id);
            if (isInOrder)
            {
                // Instead of deleting, mark as unavailable
                artWork.IsAvailable = false;
            }
            else
            {
                _context.ArtWorks.Remove(artWork);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
