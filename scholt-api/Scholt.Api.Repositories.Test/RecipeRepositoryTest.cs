using Scholt.Api.Data;
using Scholt.Api.Domain.Entities;

namespace Scholt.Api.Repositories.Test
{
    public class RecipeRepositoryTest()
    {
        public RecipeRepository mockRecipeRepository = new(new ScholtApiContext());
        public Recipe mockRecipe = new()
        {
            Name = "Test",
            Ingredients = ["Test 1", "Test 2"],
            Instructions = ["Test 1", "Test 2"]
        };

        [Fact]
        public async Task Recipes_can_be_retrieved()
        {
            var recipes = await mockRecipeRepository.Get();
            Assert.NotNull(recipes);
        }

        [Fact]
        public async Task Recipe_can_be_retrieved_by_name()
        {
            var recipe = await mockRecipeRepository.GetByName("scrambledEggs");
            Assert.NotNull(recipe);
        }

        [Fact]
        public async Task Recipe_can_be_added()
        {
            var result = await mockRecipeRepository.Add(mockRecipe);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Recipe_can_be_updated()
        {
            var result = await mockRecipeRepository.Update(mockRecipe);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Recipe_can_be_deleted()
        {
            var result = await mockRecipeRepository.Delete(mockRecipe);
            Assert.True(result.Success);
        }
    }
}
