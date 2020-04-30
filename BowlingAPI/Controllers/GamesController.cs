using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingAPI.Classes;
using BowlingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Controllers
{
    //[Authorize]
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
        public async Task<IActionResult> GetAllGames([FromQuery] GameQueryParameters queryParameters)
        {
            IQueryable<Game> games = _context.Games;

            if (queryParameters.Player != null)
            {
                games = games.Where(
                    g => g.PlayerId == queryParameters.Player);
            }
            if (queryParameters.Score != null)
            {
                games = games.Where(
                    g => g.TotalScore == queryParameters.Score);
            }

            return Ok(await games.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> PostGame([FromBody] Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                    "GetGame",
                    new { id = game.GameId },
                    game
                );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame([FromRoute] int id, [FromBody] Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Games.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame([FromRoute] int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }
    }
}