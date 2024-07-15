using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using AutoMapper;
using PokemonReviewApp.Dto;


namespace PokemonReviewApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly OwnerInterface _owner;
        private readonly IMapper _mapper;
        public OwnerController(OwnerInterface ownerInterface, IMapper mapper)
        {
            _mapper = mapper;
            _owner = ownerInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<owner>))]

        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>( _owner.GetOwners());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(owner))]

        public IActionResult GetOwnerById(int id)
        {
            if (!_owner.OwnerExist(id))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            var owner = _mapper.Map<OwnerDto>(_owner.GetOwnerById(id));

            return Ok(owner);
        
        }

        [HttpGet("OwnerExist/{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]

        public IActionResult OwnerExist(int id)
        {
            if (!_owner.OwnerExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(true);

        }
        [HttpGet("GetPokemons/{id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<pokemon>))]
        public IActionResult PokemonsOwned(int id)
        {
            if (!_owner.OwnerExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemons = _mapper.Map<PokemonDto>(_owner.PokemonsOwned(id));

            return Ok(pokemons);

        }

    }
}
