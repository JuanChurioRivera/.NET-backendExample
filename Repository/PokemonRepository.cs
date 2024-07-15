using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Interface;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonInterface
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public ICollection<pokemon> GetPokemons() { 
        
            return _context.pokemons.OrderBy(p => p.Id).ToList();
        }

        public pokemon GetPokemon(int id) {

            return _context.pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public pokemon GetPokemon(string name)
        {

            return _context.pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id) {

            var review = _context.Reviews.Where(p => p.pokemon.Id == id);

            return ((decimal)review.Sum(r => r.Rating) / review.Count());

        }

        public bool PokemonExist(int id) {

            return _context.pokemons.Any(p => p.Id == id);
        
        }

        public bool CreatePokemon(pokemon pokemon)
        {
            _context.Add(pokemon);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
