using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IPokemonInterface
    {
        ICollection<pokemon> GetPokemons();

        pokemon GetPokemon(int id);
        pokemon GetPokemon(string name);
        bool PokemonExist(int id);

        decimal GetPokemonRating(int id);

        bool CreatePokemon(pokemon pokemon);

        bool Save();
    }
}
