using PokemonReviewApp.Models;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace PokemonReviewApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        CategoryInterface _category;
        IMapper _mapper;
        public CategoryController(CategoryInterface catInterface, IMapper mapper)
        {
            _category = catInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        public IActionResult GetCategories() 
        {
            var categories = _category.GetCategories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }
        [HttpGet("GetCategoryyId/{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategory(int id)
        {
            if (!_category.CategoryExist(id))
                return NotFound();

            var category = _category.GetCategory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);   
        }
        [HttpGet("GetCategoryByName/{name}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategory(string Name)
        {
            if (!_category.CategoryExist(Name))
                return NotFound();

            var category = _category.GetCategory(Name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("GetPokemonsById/{id}")]
        [ProducesResponseType(200, Type = typeof(ICollection<pokemon>))]
        public IActionResult GetPokemonsByCategory(int id)
        {
            if (!_category.CategoryExist(id))
                return NotFound();

            var category = _category.GetPokemonsByCategory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(category);
        }

        [HttpGet("GetPokemonsByName/{name}")]
        [ProducesResponseType(200, Type = typeof(ICollection<pokemon>))]
        public IActionResult GetPokemonsByCategory(string name)
        {
            if (!_category.CategoryExist(name))
                return NotFound();

            var category = _category.GetPokemonsByCategory(name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(category);
        }


    }
}
