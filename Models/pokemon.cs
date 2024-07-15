namespace PokemonReviewApp.Models
{
    public class pokemon
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime Datebirth { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> pokemonOwners { get; set; }
        public ICollection<PokemonCategory> pokemonCategories { get; set; }
    }
}
