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
            modelBuilder.Entity<Player>().HasMany(p => p.Games).WithOne(g => g.Player);
            modelBuilder.Entity<Game>().HasMany(g => g.Frames).WithOne(f => f.Game).HasForeignKey(f => f.GameId);
            modelBuilder.Entity<Frame>().HasMany(f => f.Shots).WithOne(s => s.Frame).HasForeignKey(s => s.FrameId);

            modelBuilder.Entity<Frame>()
                .Property(f => f.TypeFlag)
                .HasConversion<int>();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<Shot> Shots { get; set; }

    }
}
