using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface CountryInterface
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);

        Country GetCountry(string name);

        ICollection<owner> GetOwners(int id);

        bool CountryExist(int id);

        bool CountryExist(string name);

    }
}
