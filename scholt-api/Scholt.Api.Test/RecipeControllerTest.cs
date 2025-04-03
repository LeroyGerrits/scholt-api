using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Scholt.Api.Controllers;
using Scholt.Api.Data;
using Scholt.Api.Dto;
using Scholt.Api.Dto.Response;
using Scholt.Api.Repositories;

namespace Scholt.Api.Test
{
    public class RecipeControllerTest
    {
        public RecipeController mockRecipeController = new(new RecipeRepository(new ScholtApiContext()));
        public RecipeDto mockRecipeDto = new()
        {
            Name = "Test",
            Ingredients = ["Test 1", "Test 2"],
            Instructions = ["Test 1", "Test 2"]
        };

        [Fact]
        public async Task Get_endpoint_returns_data_and_status_code_200()
        {
            ActionResult<IEnumerable<RecipeGetResponseDto>> result = await mockRecipeController.Get();
            Assert.NotNull(result);
            Assert.Equal(GetStatusCode(result!), StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetByName_endpoint_returns_data_and_status_code_200()
        {
            ActionResult<RecipeGetByNameResponseDto> result = await mockRecipeController.GetByName("scrambledEggs");
            Assert.NotNull(result);
            Assert.Equal(GetStatusCode(result!), StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Post_endpoint_returns_status_code_201()
        {
            ActionResult<object> result = await mockRecipeController.Post(mockRecipeDto);
            Assert.Equal(GetStatusCode(result!), StatusCodes.Status201Created);
        }

        [Fact]
        public async Task Put_endpoint_returns_status_code_204()
        {
            ActionResult<object> result = await mockRecipeController.Put(mockRecipeDto);
            Assert.Equal(GetStatusCode(result!), StatusCodes.Status204NoContent);
        }

        private static int? GetStatusCode<T>(ActionResult<T?> actionResult)
        {
            IConvertToActionResult convertToActionResult = actionResult; // ActionResult implicit implements IConvertToActionResult
            var actionResultWithStatusCode = convertToActionResult.Convert() as IStatusCodeActionResult;
            return actionResultWithStatusCode?.StatusCode;
        }
    }
}
