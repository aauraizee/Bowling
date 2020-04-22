using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Shot> Shots { get; set; }

    }
}
