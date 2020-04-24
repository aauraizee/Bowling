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
    public class FramesController : ControllerBase
    {

        private readonly BowlingContext _context;

        public FramesController(BowlingContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFrames()
        {
            return Ok(await _context.Frames.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFrame(int id)
        {
            var frame = await _context.Frames.FindAsync(id);
            if (frame == null)
            {
                return NotFound();
            }
            return Ok(frame);
        }
    }
}