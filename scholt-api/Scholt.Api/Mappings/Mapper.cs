using Scholt.Api.Domain.Entities;
using Scholt.Api.Dto;

namespace Scholt.Api.Mappings
{
    public static class Mapper
    {
        #region From Entity to DTO
        public static RecipeDto Map(this Recipe recipe)
            => new()
            {
                Name = recipe.Name,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions
            };
        #endregion

        #region From DTO to Entity
        public static Recipe Map(this RecipeDto recipeDto)
            => new()
            {
                Name = recipeDto.Name,
                Ingredients = recipeDto.Ingredients,
                Instructions = recipeDto.Instructions
            };
        #endregion
    }
}