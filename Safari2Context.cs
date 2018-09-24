using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Safari2
{
    public partial class Safari2Context : DbContext
    {
 
 
        public Safari2Context()
        {
        }

        public Safari2Context(DbContextOptions<Safari2Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("server=localhost;database=Safari2;username=postgres;password=warrior");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public DbSet<SeenAnimal> SeenAnimals { get; set; }
    }
}
