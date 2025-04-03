using Scholt.Api.Domain;
using Scholt.Api.Domain.Entities;

namespace Scholt.Api.Data.Interfaces
{
    public interface IScholtApiContext
    {
        public Task<ServiceResult> AddRecipe(Recipe recipe);
        public Task<ServiceResult> DeleteRecipe(Recipe recipe);
        public Task<IEnumerable<Recipe>> GetRecipes();
        public Task<IEnumerable<Recipe>> GetRecipes(string? name);
        public Task<ServiceResult> UpdateRecipe(Recipe recipe);
    }
}