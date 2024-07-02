using DevoraLimeArena.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevoraLimeArena.DB
{
    public class ArenaDBContext : DbContext
    {
        public DbSet<Arena> Arenas { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<History> Histories { get; set; }


        public ArenaDBContext(DbContextOptions<ArenaDBContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fighter>().HasKey(e => e.Id);
            modelBuilder.Entity<Fighter>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Arena>().HasKey(e => e.Id);
            modelBuilder.Entity<Arena>().Property(e=>e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<History>().HasKey(e => e.Id);
            modelBuilder.Entity<History>().Property(e => e.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Arena>()
                .HasMany(x=>x.Fighters)
                .WithOne(x=>x.Arena)
                .HasForeignKey(x=>x.ArenaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Arena>()
                .HasMany(x => x.History)
                .WithOne(x => x.Arena)
                .HasForeignKey(x => x.ArenaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
