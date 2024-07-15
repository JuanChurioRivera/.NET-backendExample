using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;


namespace PokemonReviewApp.Repository
{
    public class CountryRepository : CountryInterface
    {
        DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Country> GetCountries() 
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountry(int id) 
        {

            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountry(string name)
        {
            return _context.Countries.Where(c => c.Name == name).FirstOrDefault();
        }

        public bool CountryExist(int id) 
        { 
            return _context.Countries.Any(c => c.Id == id);
        }

        public bool CountryExist(string name)
        {
            return _context.Countries.Any(c => c.Name == name);
        }

        public ICollection<owner> GetOwners(int id) 
        {
            
            return _context.owners.Where(c => c.Country.Id == id).ToList();

        }
    }
}
