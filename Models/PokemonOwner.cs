namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {

        public int PokemonId { get; set; }
        public int OwnerId { get; set; }

        public pokemon pokemon { get; set; }

        public owner owner { get; set; }
    }
}
