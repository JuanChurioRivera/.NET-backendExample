
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRespository : OwnerInterface
    {
        private readonly DataContext _context;
        public OwnerRespository(DataContext context)
        {
            _context = context;
        }

        public ICollection<owner> GetOwners()
        {
            return _context.owners.OrderBy(o => o.Id).ToList();
        }

        public owner GetOwnerById(int id)
        {
            return _context.owners.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool OwnerExist(int id)
        {
            return _context.owners.Any(p  => p.Id == id);
        }

        public string OwnerCountry(int id)
        {
            var country = _context.Countries.Where(o => o.Owners.Any(o => o.Id == id)).FirstOrDefault();

            return country.Name;
        }

        public ICollection<pokemon> PokemonsOwned(int id)
        {
            return _context.pokemons.Where(p => p.pokemonOwners.Any(p => p.OwnerId == id)).ToList();
        }
    }
}
