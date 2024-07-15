using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;


namespace PokemonReviewApp.Helper
{
    public class MapProfiles : Profile
    {

        public MapProfiles() 
        {
            CreateMap<pokemon, PokemonDto>();
            CreateMap<PokemonDto, pokemon>();
            CreateMap<owner, OwnerDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}
