using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BowlingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private readonly BowlingContext _context;

        public GamesController(BowlingContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            return Ok(_context.Games.ToArray());
        }

        [HttpGet("{id}")]
        public IActionResult GetGame(int id)
        {
            var product = _context.Games.Find(id);
            return Ok(product);
        }
    }
}