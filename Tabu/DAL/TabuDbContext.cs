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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.HasIndex(x => x.Name)
                .IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.HasData(new Language
                {
                    Code = "az",
                    Name = "Azərbaycan",
                    Icon="https://cdn-icons-png.flaticon.com/512/330/33054.png"
                });

            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
