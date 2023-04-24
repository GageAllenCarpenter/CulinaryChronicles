namespace Recipes.API.Models
{
    public class Recipe : EntityBase
    {
        public List<Ingredient> Ingredients { get; set; }

        public Recipe() 
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
