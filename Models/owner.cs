﻿namespace PokemonReviewApp.Models
{
    public class owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        public Country Country { get; set; }

        public ICollection<PokemonOwner> PokemonOwner { get; set; }
    }
}
