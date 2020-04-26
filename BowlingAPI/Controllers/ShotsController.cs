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
    public class ShotsController : ControllerBase
    {

        private readonly BowlingContext _context;

        public ShotsController(BowlingContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        public async Task<IActionResult> GetAllShots([FromQuery] ShotQueryParameters queryParameters)
        {
            IQueryable<Shot> shots = _context.Shots;

            if (queryParameters.Frame != null)
            {
                shots = shots.Where(
                    s => s.FrameId == queryParameters.Frame);
            }
            if (queryParameters.Pins != null)
            {
                shots = shots.Where(
                    s => s.PinsHit == queryParameters.Pins);
            }
            if (queryParameters.IsSpare != null)
            {
                shots = shots.Where(
                    s => s.IsSpareShot == queryParameters.IsSpare);
            }
            if (queryParameters.Converted != null)
            {
                shots = shots.Where(
                    s => s.WasConverted == queryParameters.Converted);
            }
            if (queryParameters.SpareType != null)
            {
                shots = shots.Where(
                    s => s.SpareType == queryParameters.SpareType);
            }


            return Ok(await shots.ToArrayAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetShot(int id)
        {
            var shot = await _context.Shots.FindAsync(id);
            if (shot == null)
            {
                return NotFound();
            }
            return Ok(shot);
        }


        [HttpPost]
        public async Task<ActionResult<Shot>> PostShot([FromBody] Shot shot)
        {
            _context.Shots.Add(shot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    "GetShot",
                    new { id = shot.ShotId },
                    shot
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShot([FromRoute] int id, [FromBody] Shot shot)
        {
            if (id != shot.ShotId)
            {
                return BadRequest();
            }

            _context.Entry(shot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Frames.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Shot>> DeleteShot([FromRoute] int id)
        {
            var shot = await _context.Shots.FindAsync(id);
            if (shot == null)
            {
                return NotFound();
            }

            _context.Shots.Remove(shot);
            await _context.SaveChangesAsync();

            return shot;
        }
    }
}