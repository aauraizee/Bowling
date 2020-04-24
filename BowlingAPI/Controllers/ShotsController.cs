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
    public class ShotsController : ControllerBase
    {

        private readonly BowlingContext _context;

        public ShotsController(BowlingContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllShots(int id)
        {
            var shot = await _context.Shots.FindAsync(id);
            if (shot == null)
            {
                return NotFound();
            }
            return Ok(shot);
        }
    }
}