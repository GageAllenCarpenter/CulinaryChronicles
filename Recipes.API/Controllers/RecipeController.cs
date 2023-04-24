using Microsoft.AspNetCore.Mvc;
using Recipes.API.Models;
using Recipes.API.Repositories;

namespace Recipes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetAllAsync()
        {
            return await _recipeRepository.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Recipe?> GetByIdAsync(int id)
        {
           return await _recipeRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Recipe recipe)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _recipeRepository.AddAsync(recipe);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Recipe recipe)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _recipeRepository.UpdateAsync(recipe);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(Recipe recipe)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _recipeRepository.DeleteAsync(recipe);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return NotFound();
            await _recipeRepository.DeleteAsync(recipe);
            return Ok();
        }
    }
}
