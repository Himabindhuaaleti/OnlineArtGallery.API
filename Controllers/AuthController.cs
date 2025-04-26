
// STEP 5: Controllers
// File: Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using OnlineArtGallery.API.DTOs;
using OnlineArtGallery.API.Models;
using OnlineArtGallery.API.Data;
using OnlineArtGallery.API.Helpers;
using System.Linq;

namespace OnlineArtGallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly GalleryContext _context;
        private readonly JwtService _jwtService;

        public AuthController(GalleryContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == loginDto.Username && u.PasswordHash == loginDto.Password);
            if (user == null) return Unauthorized();

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = registerDto.Password, // Hash in real app!
                Role = "User"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
