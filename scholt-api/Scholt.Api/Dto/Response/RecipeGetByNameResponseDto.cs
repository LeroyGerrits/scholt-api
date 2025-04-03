namespace Scholt.Api.Dto.Response
{
    public class RecipeGetByNameResponseDto
    {
        public required RecipeGetByNameResponseDetailsDto Details { get; set; }
    }

    public class RecipeGetByNameResponseDetailsDto
    {
        public required string[] Ingredients { get; set; }
        public required int NumSteps { get; set; }
    }
}
