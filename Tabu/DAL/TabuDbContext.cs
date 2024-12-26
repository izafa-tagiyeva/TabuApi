using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Tabu.Entities;

namespace Tabu.DAL
{
    public class TabuDbContext : DbContext
    {
        public TabuDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<BannedWord> BannedWord { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabuDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
