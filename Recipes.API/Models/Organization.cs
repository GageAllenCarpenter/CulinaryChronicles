namespace Recipes.API.Models
{
    public class Organization : EntityBase
    {
        public string? Name { get; set; }
        public List<Chef> Chefs { get; set; }

        public Organization() 
        {
            Chefs = new List<Chef>();
        }
    }
}
