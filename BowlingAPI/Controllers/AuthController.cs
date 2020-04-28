using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BowlingContext _context;

        public AuthController(BowlingContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();

            if (await _context.Players.AnyAsync(p => p.Username == username))
                return BadRequest("This username already exists!");

            var playerToRegister = new Player
            {
                Username = username
            };

            byte[] passwordHash, passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            playerToRegister.PasswordHash = passwordHash;
            playerToRegister.PasswordSalt = passwordSalt;

            await _context.Players.AddAsync(playerToRegister);
            await _context.SaveChangesAsync();

            return StatusCode(201);
            
        }



    }
}