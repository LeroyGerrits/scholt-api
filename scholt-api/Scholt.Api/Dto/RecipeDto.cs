namespace Scholt.Api.Dto
{
    public class RecipeDto
    {
        public required string Name { get; set; }
        public string[] Ingredients { get; set; } = [];
        public string[] Instructions { get; set; } = [];
    }
}