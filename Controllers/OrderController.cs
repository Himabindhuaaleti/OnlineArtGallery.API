
// File: Controllers/OrderController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineArtGallery.API.Data;
using OnlineArtGallery.API.DTOs;
using OnlineArtGallery.API.Models;
using System;
using System.Linq;

namespace OnlineArtGallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly GalleryContext _context;

        public OrderController(GalleryContext context)
        {
            _context = context;
        }

        [HttpPost("place")]
        [Authorize]
        public IActionResult PlaceOrder([FromBody] OrderRequestDto request)
        {
            var username = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return Unauthorized();

            var products = _context.ArtProducts.Where(p => request.ProductIds.Contains(p.Id)).ToList();

            var order = new Order
            {
                UserId = user.Id,
                OrderDate = DateTime.Now,
                OrderDetails = products.Select(p => new OrderDetail {
                    ProductId = p.Id,
                    Quantity = 1,
                    Price = p.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}