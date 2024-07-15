using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface OwnerInterface
    {

        ICollection<owner> GetOwners();

        owner GetOwnerById(int id);

        bool OwnerExist(int id);

        string OwnerCountry(int id);

        ICollection<pokemon> PokemonsOwned(int id);

    }
}
