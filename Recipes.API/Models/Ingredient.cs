namespace Recipes.API.Models
{
    public class Ingredient : EntityBase
    {
        public string? Name { get; set; }
        public string? Quantity { get; set; }
        public string? Unit { get; set; }
    }
}
