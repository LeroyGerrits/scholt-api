using Newtonsoft.Json;
using Scholt.Api.Data.Interfaces;
using Scholt.Api.Domain;
using Scholt.Api.Domain.Entities;
using System.Reflection;

namespace Scholt.Api.Data
{
    public class ScholtApiContext : IScholtApiContext
    {
        public async Task<ServiceResult> AddRecipe(Recipe recipe)
        {
            var result = new ServiceResult();
            await Task.Run(() => result.Success = true);
            return result;
        }

        public async Task<ServiceResult> DeleteRecipe(Recipe recipe)
        {
            var result = new ServiceResult();
            await Task.Run(() => result.Success = true);
            return result;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
            => await GetRecipes(null);

        public async Task<IEnumerable<Recipe>> GetRecipes(string? name)
        {
            RecipeWrapper recipeWrapper = new();
            IEnumerable<Recipe> recipes = [];

            var dataJsonFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "data.json";
            using (StreamReader streamReader = File.OpenText(dataJsonFilePath) ?? throw new Exception("data.json could not be found"))
            {
                using var jsonTextReader = new JsonTextReader(streamReader) ?? throw new Exception("data.json does not contain valid JSON.");
                JsonSerializer serializer = new();
                await Task.Run(() => recipeWrapper = serializer.Deserialize<RecipeWrapper>(jsonTextReader) ?? throw new Exception("JSON could not be deserialized"));

                recipes = recipeWrapper.Recipes;

                if (name != null)
                {
                    recipes = recipes.Where(r => string.Equals(r.Name, name, StringComparison.OrdinalIgnoreCase));
                }
            }

            return recipes;
        }

        public async Task<ServiceResult> UpdateRecipe(Recipe recipe)
        {
            var result = new ServiceResult();
            await Task.Run(() => result.Success = true);
            return result;
        }
    }
}