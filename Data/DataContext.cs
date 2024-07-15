using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<owner> owners { get; set; }
        public DbSet<pokemon> pokemons { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }

        public DbSet<PokemonOwner> pokemonOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(p => new { p.PokemonId, p.CategoryId });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.pokemon)
                .WithMany(pc => pc.pokemonCategories)
                .HasForeignKey(c => c.PokemonId);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.category)
                .WithMany(p => p.PokemonCategories)
                .HasForeignKey(k => k.CategoryId);


            modelBuilder.Entity<PokemonOwner>()
                .HasKey(p => new { p.PokemonId, p.OwnerId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.pokemon)
                .WithMany(pc => pc.pokemonOwners)
                .HasForeignKey(c => c.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.owner)
                .WithMany(p => p.PokemonOwner)
                .HasForeignKey(k => k.OwnerId);



        }

    }
}
