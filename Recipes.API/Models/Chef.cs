namespace Recipes.API.Models
{
    public class Chef : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Recipe>? Recipes { get; set; }

        public Chef()
        {
            Recipes = new List<Recipe>();
        }
    }
}
