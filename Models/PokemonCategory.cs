﻿namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {

        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        

        public pokemon pokemon { get; set; }
        public Category category { get; set; }
    }
}
