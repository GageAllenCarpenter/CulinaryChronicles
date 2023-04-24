using Microsoft.EntityFrameworkCore;
using Recipes.API.Data;
using Recipes.API.Models;

namespace Recipes.API.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _context.GetDbSet<Recipe>().AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _context.RemoveRange(recipe.Ingredients);
            _context.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _context.GetDbSet<Recipe>().Include(r => r.Ingredients).ToListAsync();
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.GetDbSet<Recipe>().Include(r => r.Ingredients).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            _context.GetDbSet<Recipe>().Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
