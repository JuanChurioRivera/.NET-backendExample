using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using PokemonReviewApp.Dto;

using AutoMapper;
using PokemonReviewApp.Interface;


namespace PokemonReviewApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class CountryController : Controller
    {
        CountryInterface _country;
        IMapper _mapper;
        public CountryController(CountryInterface countryInterface, IMapper mapper)
        {
            _country = countryInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Country>))]
        public IActionResult GetCountries() 
        {

            var countries = _mapper.Map<ICollection<CountryDto>>(_country.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("GetCountry/{id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Country>))]

        public IActionResult GetCountry(int id) 
        {
            if (!_country.CountryExist(id))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_country.GetCountry(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Country>))]

        public IActionResult GetCountry(string name)
        {
            if (!_country.CountryExist(name))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_country.GetCountry(name));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("GetOwners/{id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Country>))]

        public IActionResult GetOwners(int id) 
        {
            if (!_country.CountryExist(id))
                return NotFound();

            var owners = _mapper.Map<ICollection<owner>>(_country.GetOwners(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners); 
        }
    }
}
