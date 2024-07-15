using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using AutoMapper;
using PokemonReviewApp.Dto;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonInterface _pokemon;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonInterface pokemonInterface, IMapper mapper)
        {
            _pokemon = pokemonInterface;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<pokemon>))]
        public IActionResult GetPokemons()
        {

            var pokemon = _mapper.Map<List<PokemonDto>>( _pokemon.GetPokemons());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonById(int id) {
        
            if(!_pokemon.PokemonExist(id))
                return NotFound();

            var pokemon = _mapper.Map<PokemonDto>( _pokemon.GetPokemon(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);

        }

        [HttpGet("{id}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonRating(int id)
        {
            if (!_pokemon.PokemonExist(id))
                return NotFound();

            var rating = _pokemon.GetPokemonRating(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]

        public IActionResult CreatePokemon([FromBody] PokemonDto pokemon)
        {
            if(pokemon == null)
                return BadRequest(ModelState);

            var exists = _pokemon.GetPokemons()
                .Where(p => p.Name.TrimEnd().ToLower() ==  pokemon.Name.TrimEnd().ToLower()).FirstOrDefault();

            if (exists != null)
            {
                ModelState.AddModelError("", "Pokemon Already Exist");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var newPokemon = _mapper.Map<pokemon>(pokemon);

            var changes = _pokemon.CreatePokemon(newPokemon);

            if (!changes)
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500,ModelState);
            }

            return Ok("Succesfully created");
        }

    }
}