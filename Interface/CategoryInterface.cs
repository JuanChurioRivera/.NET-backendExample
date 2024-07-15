using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface CategoryInterface
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int id);
        Category GetCategory(string name);

        ICollection<pokemon> GetPokemonsByCategory(int id);

        ICollection<pokemon> GetPokemonsByCategory(string name);

        bool CategoryExist(int id);

        bool CategoryExist(string name);

    }
}
