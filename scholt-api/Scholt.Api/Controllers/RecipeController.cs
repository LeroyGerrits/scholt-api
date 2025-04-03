using Microsoft.AspNetCore.Mvc;
using Scholt.Api.Dto;
using Scholt.Api.Dto.Request;
using Scholt.Api.Dto.Response;
using Scholt.Api.Mappings;
using Scholt.Api.Repositories.Interfaces;

namespace Scholt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController(IRecipeRepository recipeRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeGetResponseDto>>> Get(RecipeGetRequestDto? request)
        {
            var recipes = await recipeRepository.Get();

            if (request != null)
            {
                // Additional filter logic if the request DTO contains any values
            }

            return Ok(new RecipeGetResponseDto() { RecipeNames = recipes.Select(r => r.Name).ToArray() });
        }

        [HttpGet("details/{name}")]
        public async Task<ActionResult<RecipeGetByNameResponseDto>> GetByName(string name)
        {
            var recipe = await recipeRepository.GetByName(name);

            if (recipe == null)
                return NotFound();

            return Ok(new RecipeGetByNameResponseDto()
            {
                Details = new RecipeGetByNameResponseDetailsDto()
                {
                    Ingredients = recipe.Ingredients,
                    NumSteps = recipe.Instructions.Length
                }
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecipeDto recipeDto)
        {
            var result = await recipeRepository.Add(Mapper.Map(recipeDto));

            if (!result.Success)
                return BadRequest(result.Messages);

            return CreatedAtAction("Post", null);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RecipeDto recipeDto)
        {
            var result = await recipeRepository.Update(Mapper.Map(recipeDto));

            if (!result.Success)
                return BadRequest(result.Messages);

            return NoContent();
        }
    }
}