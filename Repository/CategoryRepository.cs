using PokemonReviewApp.Models;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Data;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : CategoryInterface
    {
        DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id) 
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetCategory(string name)
        {
            return _context.Categories.Where(c => c.Name == name).FirstOrDefault();
        }

        public ICollection<pokemon> GetPokemonsByCategory(int id) 
        {
            var category = GetCategory(id);

            return _context.pokemons.Where(p => p.Id == category.Id).ToList();
        }

        public ICollection<pokemon> GetPokemonsByCategory(string name)
        {
            var category = GetCategory(name);

            return _context.pokemons.Where(p => p.Name == category.Name).ToList();
        }

        public bool CategoryExist(int id) 
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CategoryExist(string name)
        {
            return _context.Categories.Any(c => c.Name == name);
        }


    }


}
