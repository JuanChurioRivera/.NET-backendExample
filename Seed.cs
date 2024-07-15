using PokemonReviewApp.Data;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.pokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    new PokemonOwner()
                    {
                        pokemon = new pokemon()
                        {
                            Name = "Pikachu",
                            Datebirth = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Description = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Description = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu",Description = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        owner = new owner()
                        {
                            Name = "Jack",
                            
                            Gym = "Brocks Gym",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwner()
                    {
                        pokemon = new pokemon()
                        {
                            Name = "Squirtle",
                            Datebirth = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Description = "squirtle is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Squirtle",Description = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Squirtle", Description = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        owner = new owner()
                        {
                            Name = "Harry",
                     
                            Gym = "Mistys Gym",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new PokemonOwner()
                    {
                        pokemon = new pokemon()
                        {
                            Name = "Venasuar",
                            Datebirth = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Veasaur",Description = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Veasaur",Description = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Veasaur",Description = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        owner = new owner()
                        {
                            Name= "Ash",
                          
                            Gym = "Ashs Gym",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.pokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
