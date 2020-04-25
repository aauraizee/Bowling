using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingAPI.Classes;
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
        public async Task<IActionResult> GetAllFrames([FromQuery] FrameQueryParameters queryParameters)
        {
            IQueryable<Frame> frames = _context.Frames;

            if (queryParameters.Game != null)
            {
                frames = frames.Where(
                    f => f.GameId == queryParameters.Game);
            }
            if (queryParameters.Value != null)
            {
                frames = frames.Where(
                    f => f.Value == queryParameters.Value);
            }
            if (queryParameters.Type != null)
            {
                frames = frames.Where(
                    f => f.TypeFlag == queryParameters.Type);
            }

            return Ok(await frames.ToArrayAsync());
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