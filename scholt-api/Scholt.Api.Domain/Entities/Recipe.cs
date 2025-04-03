namespace Scholt.Api.Domain.Entities
{
    public class Recipe
    {
        public required string Name { get; set; }
        public string[] Ingredients { get; set; } = [];
        public string[] Instructions { get; set; } = [];
    }
}