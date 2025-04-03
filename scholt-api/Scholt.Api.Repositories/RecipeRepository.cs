using Scholt.Api.Data.Interfaces;
using Scholt.Api.Domain;
using Scholt.Api.Domain.Entities;
using Scholt.Api.Repositories.Interfaces;

namespace Scholt.Api.Repositories
{
    public class RecipeRepository(IScholtApiContext scholtApiContext) : IRecipeRepository
    {
        public async Task<ServiceResult> Add(Recipe recipe)
            => await scholtApiContext.AddRecipe(recipe);

        public async Task<ServiceResult> Delete(Recipe recipe)
            => await scholtApiContext.DeleteRecipe(recipe);

        public async Task<IEnumerable<Recipe>> Get()
            => await scholtApiContext.GetRecipes();

        public async Task<Recipe?> GetByName(string name)
        {
            var recipes = await scholtApiContext.GetRecipes(name);
            return recipes.FirstOrDefault();
        }

        public async Task<ServiceResult> Update(Recipe recipe)
            => await scholtApiContext.UpdateRecipe(recipe);
    }
}