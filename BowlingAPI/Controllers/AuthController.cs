using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BowlingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BowlingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BowlingContext _context;

        private readonly IConfiguration _config;

        public AuthController(BowlingContext context, IConfiguration config)
        {
            _config = config;
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
                Username = username,
                GamesPlayed = 0,
                CurrentAverage = 0
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


        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            username = username.ToLower();
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Username == username);

            if (player == null)
                return Unauthorized();

            using (var hmac = new System.Security.Cryptography.HMACSHA512(player.PasswordSalt))
            {
                var comparisonHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < comparisonHash.Length; i++)
                {
                    if (comparisonHash[i] != player.PasswordHash[i])
                        return Unauthorized();
                }
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, player.PlayerId.ToString()),
                new Claim(ClaimTypes.Name, player.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });




        }



    }
}