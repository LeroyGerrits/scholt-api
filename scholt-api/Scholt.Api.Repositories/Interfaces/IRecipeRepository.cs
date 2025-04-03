using Scholt.Api.Domain;
using Scholt.Api.Domain.Entities;

namespace Scholt.Api.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> Get();
        Task<Recipe?> GetByName(string name);
        Task<ServiceResult> Add(Recipe recipe);
        Task<ServiceResult> Update(Recipe recipe);
        Task<ServiceResult> Delete(Recipe recipe);
    }
}